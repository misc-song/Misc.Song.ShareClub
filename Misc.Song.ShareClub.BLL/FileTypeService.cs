using Misc.Song.ShareClub.IBLL;
using Misc.Song.ShareClub.IDAL;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.BLL
{
    public class FileTypeService : BaseService<FileType>, IFileTypeService
    {
        public FileTypeService(IBaseDal<FileType> dal) : base(dal)
        {
        }
    }
}
