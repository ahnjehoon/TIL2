using Microsoft.EntityFrameworkCore;
using rest_api_test.Models;

namespace rest_api_test.Util
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LANGUAGE_INFO> LANGUAGE_INFO { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //언젠간 MySQL이 된다면...
            //optionsBuilder.UseMySQL(@"User Id=root;Password=1111;Host=localhost;Database=develop;");
            //optionsBuilder.UseMySQL(@"Server=localhost;Database=develop;Uid=root;Pwd=1111;");

            //임시방편으로 MSSQL
            optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;Initial Catalog=develop;Persist Security Info=True;User ID=sa;Password=1111");
        }
    }
}
