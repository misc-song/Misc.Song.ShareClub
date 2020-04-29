using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Misc.Song.ShareClub.BLL
{
    public class UserinfoService : BaseService<UserInfo>, IUserInfoService
    {
        public UserinfoService(IBaseDal<UserInfo> dal) : base(dal)
        {
        }
    }
}
