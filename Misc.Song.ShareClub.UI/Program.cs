using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Misc.Song.ShareClub.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("hosting.json").Build();
            var urls = config.GetSection("server.urls").Value;
            WebHost.CreateDefaultBuilder(args).UseKestrel(options =>
            {
                options.Limits.MaxRequestBodySize = int.MaxValue;
            }).UseUrls(urls).UseStartup<Startup>().Build().Run();
        }


    }
}
