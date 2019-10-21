using System;
using System.IO;
using Microsoft.Extensions.Configuration;

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
            Console.WriteLine("Hello World!");
        }
    }
}
