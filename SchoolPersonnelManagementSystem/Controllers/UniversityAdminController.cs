using Microsoft.AspNetCore.Mvc;
using SchPeoSystem.Models;
using SchPeoSystem.Services;
using System.Reflection;
using System.Text;

namespace SchPeoSystem.Controllers
{
    public class UniversityAdminController : Controller
    {
        /// <summary>
        /// 默认页面，信息页面为空
        /// </summary>
        /// <returns></returns>
        [HttpGet("UniversityAdmin")]
        //[ValidateAntiForgeryToken]
        public IActionResult UniversityAdminIndex(string? page)
        {
            if (string.IsNullOrEmpty(page)) return View();
            // 非Ajax请求【刷新】返回整个页面防止在刷新后只剩子页面
            if (Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return View();
            }
            else switch (page)
                {
                    case "Teacher":
                        {
                            var teachers = TeacherService.GetAllActiveTeachers(); // 从数据库获取账号信息
                            return PartialView("TeacherPartial", teachers);
                        }
                    case "Stuff":
                        return PartialView("StuffPartial");
                    // 添加更多的页面处理逻辑
                    default:
                        return RedirectToAction("UniversityAdminIndex"); // 默认返回主页
                }
        }
        /// <summary>
        /// 根据输入的信息进行教师信息检索
        /// </summary>
        [HttpPost]
        public IActionResult SearchTeacherByRules(string? Name, string Status, string? School, string? JobPosition, string? Description)
        {
            if (ModelState.IsValid)
            {
                // 去除空格
                if (!string.IsNullOrEmpty(Name)) Name = Name.Trim();
                if (!string.IsNullOrEmpty(School)) School = School.Trim();
                if (!string.IsNullOrEmpty(JobPosition)) JobPosition = JobPosition.Trim();
                if (!string.IsNullOrEmpty(Description)) Description = Description.Trim();
                // 调用Service检索账号信息
                var _accList = TeacherService.GetTeacherByRules(Name, Status, School, JobPosition, Description);
                // 回传表单信息，保持前端信息不改变
                ViewBag.Name = Name;
                ViewBag.Status = Status;
                ViewBag.School = School;
                ViewBag.JobPosition = JobPosition;
                ViewBag.Description = Description;
                return PartialView("AccountPartial", _accList);
            }
            else return View();
        }
    }
}
