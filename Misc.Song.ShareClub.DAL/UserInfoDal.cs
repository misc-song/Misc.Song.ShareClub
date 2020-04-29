using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.DAL
{
    public class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
        public ShareContext _aDBContext { get; set; }
        public UserInfoDal(ShareContext context) : base(context)
        {
            this._aDBContext = context;
        }
    }
}
