using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misc.Song.ShareClub.IBLL;

namespace YS.OA.Misc.Controllers
{
    public class LoginController : Controller
    {


        public IUserInfoService uInfoService { get; }
        public LoginController(IUserInfoService userInfoService)
        {
            uInfoService = userInfoService;
        }
        //pages
        public IActionResult Index()
        {
            return View();
        }

        //apis
        //验证登录 (判断用户角色)
        public IActionResult CheckLogin(string Account, string Password)
        {

            if (string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password))
            {
                return Content("System Error");
            }
            var uinfo = uInfoService.GetEntity(u => u.userName == Account && u.userPwd == Password);

            if (uinfo == null)
            {
                return new JsonResult(new { returnCode = 500, serverData = "error" });
            }
            else
            {
                string guid = System.Guid.NewGuid().ToString();
                //保存数据到session
                HttpContext.Session.SetString("token", guid);
                HttpContext.Session.SetString("Account", Account);
                HttpContext.Session.SetString("uid", uinfo.id.ToString());
                HttpContext.Session.SetString("Password", Password);
                //var res =   HttpContext.Session.GetString("Password");
                return new JsonResult(new { returnCode = 200 });
            }
        }
        //根据登录的token 获取用户信息
        public IActionResult LoadUserInfo(string token, string uid)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(uid))
            {
                return Content("System Error");
            }
            int id = int.Parse(uid);
            var uinfo = uInfoService.GetEntity(u => u.id == id);
            return new JsonResult(uinfo);
        }

        public IActionResult SafetyExit()
        {
            try
            {
                HttpContext.Session.Clear();
            }
            catch
            {
                return new JsonResult(new { returnCode = 404, serverData = "no" });
            }
            return new JsonResult(new { returnCode = 200, serverData = "ok" });
        }
    }
}