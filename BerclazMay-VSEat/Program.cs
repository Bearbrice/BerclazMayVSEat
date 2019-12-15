using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using BLL;
using DTO;

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
