using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRPBin.Models;

namespace TRPBin.db
{
    public class ApplicationContext : DbContext
    {
        public DbSet<RawTRPData> TRPData { get; set; }

        public string DbPath { get; }

        public ApplicationContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "trpbin.db");
            Console.WriteLine(DbPath);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}