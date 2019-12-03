using Microsoft.EntityFrameworkCore;
using RestAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIServer.Data
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {
        }

        public DbSet<LanguageInfo> LanguageInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageInfo>().ToTable("LanguageInfo");
        }
    }
}
