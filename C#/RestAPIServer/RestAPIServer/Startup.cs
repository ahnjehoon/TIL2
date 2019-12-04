using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestAPIServer.Data;
using System;
using System.IO;

namespace RestAPIServer
{
    public class Startup
    {

        String DBConnectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // 로컬일때
            // this.DBConnectionString = Configuration.GetConnectionString("MSSQL");
            // 개발서버
            this.DBConnectionString = File.ReadAllText(@"C:\DBConnection.txt");
            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(DBConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // 마이그레이션 테스트
            // 안된다..
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<MSSQLContext>();
            //    context.Database.Migrate();
            //    //context.Database.EnsureCreated();
            //}
        }

    }
}
