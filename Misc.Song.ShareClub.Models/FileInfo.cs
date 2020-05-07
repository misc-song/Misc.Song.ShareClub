using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
    public class FileInfo
    {
        [Key]
        public int id { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
        public long fileSize { get; set; }
        public int PageView { get; set; }  //访问量量
        public int downloadCount { get; set; }  //下载量
        public DateTime UploadTime { get; set; }                //文件上传时间
        public virtual UserInfo User { get; set; }   //外键 关联用户表
        public virtual FileType FType { get; set; }  //文件类别

    }
}
