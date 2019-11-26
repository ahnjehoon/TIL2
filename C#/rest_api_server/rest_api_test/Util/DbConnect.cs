using Microsoft.EntityFrameworkCore;

namespace rest_api_test.Util
{
    public class DbConnect : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"User Id=root;Password=1111;Host=localhost;Database=develop;");
        }
    }
}
