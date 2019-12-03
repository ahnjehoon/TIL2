using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace rest_api_test.Models
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext (DbContextOptions<MSSQLContext> options)
            : base(options)
        {
        }

        public DbSet<LanguageInfo> LanguageInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageInfo>().ToTable("LanguageInfo");
        }
    }
}
