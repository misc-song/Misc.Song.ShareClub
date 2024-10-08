﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.Models;
using Misc.Song.ShareClub.App.Filters;
using Misc.Song.ShareClub.App.Models;

namespace Misc.Song.ShareClub.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IUserInfoService _userInfoService { get; }
   
        public HomeController(ILogger<HomeController> logger,IUserInfoService userInfoService)
        {
            _logger = logger;
            this._userInfoService = userInfoService;
        }
      //  [LoginFilter]
        public IActionResult Index()
        {
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
