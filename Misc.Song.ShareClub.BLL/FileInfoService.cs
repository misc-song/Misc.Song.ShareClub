using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.BLL
{
    public class FileInfoService : BaseService<FileInfo>, IFileInfoService
    {
        public FileInfoService(IBaseDal<FileInfo> dal) : base(dal)
        {
        }
    }
}
