using Microsoft.AspNetCore.Mvc;
using SchPeoSystem.Services;
namespace SchPeoSystem.Controllers
{
    /// <summary>
    /// Login页面的Controller，负责账号登录的处理
    /// </summary>
    public class LoginPageController : Controller
    {
        /// <summary>
        /// 默认页面启动函数，展示页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取前端传来的登录请求，进行账户、密码校验
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns>登录成功：跳转Page 登录失败：写回错误消息、停留当前页面</returns>
        [HttpPost]
        public IActionResult Index(string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                // 去除空格
                Username = Username.Trim();
                Password = Password.Trim();

                var user = AccountService.CheckUsernameAndPassword(Username, Password);

                if (user != null && user.Message is null)
                {
                    // 登录成功，跳转到主页面
                    return RedirectToAction("", "SystemAdmin");
                }
                else
                {
                    // 登录失败，显示错误提示【Service完成了错误信息处理，直接抛出】
                    //ViewData["ErrorMessage"] = "用户名或密码错误，请重新输入。";
                    ViewData["ErrorMessage"] = user.Message;
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "请输入有效的用户和密码";
            }
            return View();
        }
    }
}
