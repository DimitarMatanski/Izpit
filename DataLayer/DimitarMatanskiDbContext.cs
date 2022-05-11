using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DimitarMatanskiDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests  { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DimitarMatanskiDbContext(string connectionString = "")
        {
            _connectionString = connectionString;
        }

        public DimitarMatanskiDbContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(@"Server=MITKO-PC\SQLEXPRESS;Database=DimitarMatanski;Trusted_Connection=True;");
        }

    }
}
