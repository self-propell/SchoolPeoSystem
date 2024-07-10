using Microsoft.AspNetCore.Mvc;
using SchPeoSystem.Models;
using SchPeoSystem.Services;
using System.Reflection;

namespace SchPeoSystem.Controllers
{
    public class SystemAdminController : Controller
    {
        /// <summary>
        /// 默认页面，信息页面为空
        /// </summary>
        /// <returns></returns>
        [HttpGet("SystemAdmin")]
        //[ValidateAntiForgeryToken]
        public IActionResult SystemAdminIndex(string? page)
        {
            if(string.IsNullOrEmpty(page)) return View();
            // 非Ajax请求【刷新】返回整个页面防止在刷新后只剩子页面
            if (Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return View();
            }
            else switch (page)
                {
                    case "Account":
                        {
                            var accounts = AccountService.GetAllUndeletedAccounts(); // 从数据库获取账号信息
                            return PartialView("AccountPartial", accounts);
                        }
                case "System":
                    return PartialView("SystemPartial");
                // 添加更多的页面处理逻辑
                default:
                    return RedirectToAction("SystemAdminIndex"); // 默认返回主页
                }
        }

        /// <summary>
        /// Account子页面调用，进行账号信息搜索
        /// </summary>
        /// <param name="account"></param>
        /// <param name="status"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SearchAcc(string? AccId, string Status, string? Description)
        {
            if (ModelState.IsValid)
            {
                // 去除空格
                if (!string.IsNullOrEmpty(AccId))AccId = AccId.Trim();
                if (!string.IsNullOrEmpty(Description)) Description = Description.Trim();
                // 调用Service检索账号信息
                var _accList = AccountService.GetAccountsBySearch(AccId, Status,Description);
                // 回传表单信息，保持前端信息不改变
                ViewBag.AccId = AccId;
                ViewBag.Status = Status;
                ViewBag.Description = Description;
                return PartialView("AccountPartial", _accList);
            }
            else return View();
        }

        /// <summary>
        /// 重置账号密码接口，前端返回id[List]
        /// </summary>
        /// <param name="AccSelModel"></param>
        /// <returns>重置成功/失败的信息</returns>
        [HttpPost]
        public IActionResult ResetAccPasswd([FromBody] List<string> AccSelModel)
        {
            if (ModelState.IsValid)
            {
                // 如果没有传ID【？】返回请求报错
                if (AccSelModel == null || AccSelModel.Count == 0)
                {
                    return BadRequest("请至少选择一个账号！");
                }
                // 保存每一个操作处理结果
                var resetResults = new Dictionary<string, bool>();
                // 对每一个ID处理重置密码
                foreach (var _accId in AccSelModel)
                {
                    var result = AccountService.ResetAccPasswd(_accId);
                    resetResults[_accId] = result;
                }
                var accounts = AccountService.GetAllAccounts(); // 从数据库获取账号信息
                // 如果全部更新成功
                if (resetResults.Count == AccSelModel.Count) 
                {
                    string Message = "密码更新成功！数量：" + AccSelModel.Count.ToString();
                    return Json(new { success = true, result = Message });
                }
                // results数组数量和AccSel数量不相同出现更新失败
                else
                {
                    List<string> notInResults = AccSelModel.Where(accId => !resetResults.ContainsKey(accId)).ToList();
                    string Message = notInResults.Count.ToString()+"个密码更新失败！ID:"
                        + string.Join(",", notInResults) ;
                    return Json(new { success = false, result = Message });
                }
                
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 切换账号停用启用状态接口，前端返回id[List]
        /// </summary>
        /// <param name="AccSelModel"></param>
        /// <returns>状态切换成功/失败的信息</returns>
        [HttpPost]
        public IActionResult FreezeAcc([FromBody] List<string> AccSelModel)
        {
            if (ModelState.IsValid)
            {
                // 如果没有传ID【？】返回请求报错
                if (AccSelModel == null || AccSelModel.Count == 0)
                {
                    return BadRequest("请至少选择一个账号！");
                }
                // 保存每一个操作处理结果
                var resetResults = new Dictionary<string, bool>();
                // 对每一个ID处理
                foreach (var _accId in AccSelModel)
                {
                    var result = AccountService.FreezeAcc(_accId);
                    resetResults[_accId] = result;
                }
                var accounts = AccountService.GetAllAccounts(); // 从数据库获取账号信息
                // 如果全部更新成功
                if (resetResults.Count == AccSelModel.Count)
                {
                    string Message = "数量："+AccSelModel.Count.ToString();
                    return Json(new { success = true, result = Message });
                }
                // results数组数量和AccSel数量不相同出现更新失败
                else
                {
                    List<string> notInResults = AccSelModel.Where(accId => !resetResults.ContainsKey(accId)).ToList();
                    string Message = notInResults.Count.ToString() + string.Join(",", notInResults);
                    return Json(new { success = false, result = Message });
                }

            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// 账号删除功能【标记为删除】
        /// </summary>
        /// <param name="AccSelModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteAcc([FromBody] List<string> AccSelModel)
        {
            if (ModelState.IsValid)
            {
                // 如果没有传ID【？】返回请求报错
                if (AccSelModel == null || AccSelModel.Count == 0)
                {
                    return BadRequest("请至少选择一个账号！");
                }
                // 保存每一个操作处理结果
                var resetResults = new Dictionary<string, bool>();
                // 对每一个ID处理
                foreach (var _accId in AccSelModel)
                {
                    var result = AccountService.DeleteAcc(_accId);
                    resetResults[_accId] = result;
                }
                var accounts = AccountService.GetAllAccounts(); // 从数据库获取账号信息
                // 如果全部成功
                if (resetResults.Count == AccSelModel.Count)
                {
                    string Message = "数量：" + AccSelModel.Count.ToString();
                    return Json(new { success = true, result = Message });
                }
                // results数组数量和AccSel数量不相同出现更新失败
                else
                {
                    List<string> notInResults = AccSelModel.Where(accId => !resetResults.ContainsKey(accId)).ToList();
                    string Message = notInResults.Count.ToString() + string.Join(",", notInResults);
                    return Json(new { success = false, result = Message });
                }

            }
            else
            {
                return View();
            }
        }
    }
}
