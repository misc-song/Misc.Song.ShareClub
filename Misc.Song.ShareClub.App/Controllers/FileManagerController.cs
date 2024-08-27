using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.Models;

namespace Misc.Song.ShareClub.UI.Controllers
{
    public class FileManagerController : Controller
    {

        public IFileInfoService _fileInfoService { get; }
        public IUserInfoService _userInfoService { get; }

        public FileManagerController(IFileInfoService fileInfoService, IUserInfoService userInfoService)
        {
            this._fileInfoService = fileInfoService;
            this._userInfoService = userInfoService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadFile()
        {
            string uid = HttpContext.Session.GetString("uid");
            int id = 0;
            if (!string.IsNullOrEmpty(uid))
            {
                id = int.Parse(uid);
            }
            var uifo = _userInfoService.GetEntity(u => u.id == id);

            //读取文件
            var files = Request.Form.Files;
            if (files.Count <= 0)              //上传的文件为空返回错误
            {
                return new JsonResult(new { ReturnCode = 500, serverData = "Server Error" });
            }
            foreach (var file in files)
            {
                var Guid = System.Guid.NewGuid().ToString("N");
                var fileExtension = file.FileName.Split('.');
                var path = System.AppDomain.CurrentDomain.BaseDirectory;
                if (!Directory.Exists(path + "Uploads"))//判断文件夹是否存在，不存在则创建
                { 
                    Directory.CreateDirectory(path + "Uploads");
                }
                string fileFullName = "Uploads\\" + fileExtension.First() + "_" + Guid + $".{fileExtension.Last()}";//拼接文件路径名称
                                                                                                                    // long fileSize = file.Length;
                using (FileStream fs = System.IO.File.Create(path + fileFullName))//创建文件流
                {
                    file.CopyTo(fs);//将上载文件的内容复制到目标流
                    fs.Flush();//清除此流的缓冲区并导致将任何缓冲数据写入
                }
                ShareClub.Models.FileInfo tempFileInfo = new ShareClub.Models.FileInfo()
                {
                    fileName = file.FileName,
                    fileSize = file.Length,
                    PageView = 0,
                    downloadCount = 0,
                    path = fileFullName,
                    UploadTime = System.DateTime.Now,
                    User = uifo,

                };
                _fileInfoService.AddEntity(tempFileInfo);         //问题 一次存储
            }
            return new JsonResult(new { ReturnCode = 200, serverData = "Server OK" });
        }
    }
}