using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Storage;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.UI.Filters;

namespace Misc.Song.ShareClub.UI.Controllers
{
    public class ResultController : Controller
    {
        public IFileInfoService _fileInfoService { get; }
        public IUserInfoService _userInfoService { get; }


        public ResultController(IFileInfoService fileInfoService, IUserInfoService userInfoService)
        {
            this._fileInfoService = fileInfoService;
            _userInfoService = userInfoService;
        }

        [LoginFilter]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetData(int offset, int limit, string order)
        {
            int total = 0;
            int pageindex = offset / limit;
            bool ascend = true;
            if(order!="asc")
            {
                ascend = false;
            }
            var res = _fileInfoService.GetPageEntity(pageindex, limit, out total, u => true, u => u.id, false);

            //foreach(var i in rows)
            //{
            //    var temp = _userInfoService.GetEntity(u => u.id == i.User.id);
            //   i.User = temp.userName;
            //}
            var rows = from i in res
                       where true
                       select new
                       {
                           i.id,
                           i.downloadCount,
                           fType = i.FType,
                           i.fileName,
                           i.fileSize,
                           i.PageView,
                           i.path,
                           uploadTime = i.UploadTime,
                           i.User.userName
                       };
            return new JsonResult(new
            {
                rows,
                total
            });
        }

        //public IActionResult Download(string id)
        //{
        //    return null;
        //}

        public IActionResult Download(int id)
        {
            var file = _fileInfoService.GetEntity(u => u.id == id);
            //文件路径
            string path = System.AppDomain.CurrentDomain.BaseDirectory + file.path;
            //获取文件的ContentType
            var provider = new FileExtensionContentTypeProvider();
            var memi = provider.Mappings[Path.GetExtension(path)];
            var result = File(new FileStream(path, FileMode.Open, FileAccess.Read), memi, System.Guid.NewGuid().ToString("N") + Path.GetExtension(path));
            //提交数据库
            file.downloadCount++;
            var newfile = file;
            bool ok = _fileInfoService.ModifyEntity(newfile);
            return result;
        }
    }
}
