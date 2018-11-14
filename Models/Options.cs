using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebServerProj
{
    public static class Options
    {
        private static string _root;
        public static string Root { get { return _root; } }

        static Options()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true);

            IConfiguration configuration = builder.Build();

            _root = configuration["root"];
            
        }
    }
}