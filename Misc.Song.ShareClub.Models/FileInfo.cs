using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
   public  class FileInfo
    {
        [Key]
        public int id { get; set; }
        public string path { get; set; }
        public string fileName { get; set; }
        public int fileSize { get; set; }
        public virtual UserInfo User { get; set; }   //外键 关联用户表

    }
}
