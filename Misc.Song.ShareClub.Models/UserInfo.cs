using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
    public class UserInfo
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public string userPwd { get; set; }
        public string avatar { get; set; }
        public string gender { get; set; }
    }
}
