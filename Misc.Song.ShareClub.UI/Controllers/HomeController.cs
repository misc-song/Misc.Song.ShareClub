using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.Models;
using Misc.Song.ShareClub.UI.Models;

namespace Misc.Song.ShareClub.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      //  public OADBContext dBContext { set; get; }
        public IUserInfoService _userInfoService { get; }
        //public AccountController(IAccountService accountService, OADBContext oADBContext)
        //{
        //    dBContext = oADBContext;
        //    _accountService = accountService;
        //}
        public HomeController(ILogger<HomeController> logger,IUserInfoService userInfoService)
        {
            _logger = logger;
            this._userInfoService = userInfoService;
        }

        public IActionResult Index()
        {
            UserInfo userInfo = new UserInfo()
            {
                userName = "songhejun",
                userPwd = "123",
                gender = "nv",
                avatar = ""
            };
           var ok =   _userInfoService.AddEntity(userInfo);
            if(ok)
            {
                ViewData["ok"] = "ok";
            }
            else
            {
                ViewData["ok"] = "no";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
