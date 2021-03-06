﻿using Aquahach.EFDB;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
namespace Aquahach
{
    public class AquahackContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<SoilItem> Soil { get; set; }
        public DbSet<PlantOnSoil> PlantsOnSoil { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlString;

            sqlString = new SqlConnectionStringBuilder()

            {

                DataSource = "(local)",//"192.168.30.150", // Server name

                InitialCatalog = "Aquahack",  //Database

                UserID = "sa",         //Username

                Password = "Gago246hpmp"//"eas99",  //Password

            };
            optionsBuilder.UseSqlServer(sqlString.ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PlantOnSoil>()
                .HasKey(c => new { c.PlantId, c.SoilId });

        }

    }


}
