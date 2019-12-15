using Microsoft.Extensions.Configuration;
using System.IO;

namespace BerclazMay_VSEat
{
    class Program
    {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

        static void Main(string[] args)
        {

        }
    }
}
