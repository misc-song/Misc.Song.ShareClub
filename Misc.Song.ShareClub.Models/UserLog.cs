using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
    public class UserLog
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }        //城市
        public string latitude { get; set; }    //纬度
        public string longitude { get; set; }   //经度
        public string ipAddress { get; set; }   //ip地址

    }
}
