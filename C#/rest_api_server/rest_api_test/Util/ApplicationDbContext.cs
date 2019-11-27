using Microsoft.EntityFrameworkCore;
using rest_api_test.Models;

namespace rest_api_test.Util
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LANGUAGE_INFO> LANGUAGE_INFO { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"User Id=root;Password=1111;Host=localhost;Database=develop;");
        }
    }
}
