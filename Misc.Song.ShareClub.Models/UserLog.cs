using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Misc.Song.ShareClub.Models
{
    //当页面发生跳转时候记录用户的访问记录
    public class UserLog
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }        //城市
        public string latitude { get; set; }    //纬度
        public string longitude { get; set; }   //经度
        public string ipAddress { get; set; }   //ip地址
        public string userName { get; set; }    // 匿名访问的时候 用户名为空
        public DateTime dateTime { get; set; }  //用户访问时间

    }
}
