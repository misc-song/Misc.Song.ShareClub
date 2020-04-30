using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
    public class FileType
    {
        [Key]
        public int id { get; set; }
        public string typeName { get; set; }    //类型名称
    }
}
