using Microsoft.EntityFrameworkCore;
using Misc.Song.ShareClub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misc.Song.ShareClub.DataAccess
{
    public class ShareContext : DbContext
    {
        public ShareContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }
        public DbSet<UserInfo> userInfos { get; set; }
        public DbSet<FileInfo> fileInfos { get; set; }
        public DbSet<UserLog> userLogs { get; set; }
    }
}
