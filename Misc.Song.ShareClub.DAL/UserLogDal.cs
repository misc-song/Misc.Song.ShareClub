using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.DAL
{
    public class UserLogDal : BaseDal<UserLog>, IUserLogDal
    {
        public UserLogDal(ShareContext context) : base(context)
        {
        }
    }
}
