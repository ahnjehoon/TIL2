using Microsoft.EntityFrameworkCore;
using RestAPIServer.Models;
using RestAPIServer.Models.System;

namespace RestAPIServer.Data
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Common
            modelBuilder.Entity<CommonCode>(entity =>
            {
                entity.HasKey(column => new { column.Code, column.CodeType });
                entity.ToTable("CommonCode");
            });
            #endregion

            #region Resource
            #endregion

            #region SensorData
            modelBuilder.Entity<SensorCurrentData>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorCurrentData");
            });
            modelBuilder.Entity<SensorRawData>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorRawData");
            });
            modelBuilder.Entity<SensorStatisticsMinute>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorStatisticsMinute");
            });
            modelBuilder.Entity<SensorStatisticsHour>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorStatisticsHour");
            });
            modelBuilder.Entity<SensorStatisticsDay>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorStatisticsDay");
            });
            modelBuilder.Entity<SensorStatisticsMonth>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("SensorStatisticsMonth");
            });
            #endregion

            #region System
            modelBuilder.Entity<LanguageInfo>().ToTable("LanguageInfo");
            modelBuilder.Entity<FileManager>().ToTable("FileManager");
            #endregion
        }

        public DbSet<LanguageInfo> LanguageInfo { get; set; }

        public DbSet<FileManager> FileManager { get; set; }

        public DbSet<SensorCurrentData> SensorCurrentData { get; set; }
    }
}
