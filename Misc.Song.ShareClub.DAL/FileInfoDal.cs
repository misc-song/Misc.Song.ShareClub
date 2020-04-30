using Misc.Song.ShareClub.DataAccess;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.DAL
{
    public class FileInfoDal:BaseDal<FileInfo>,IFileInfoDal
    {
        public FileInfoDal(ShareContext context) : base(context)
        {
        }
    }
}
