using System;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
	public class FootballLeagueDbContext:DbContext
	{
		public DbSet<Team> Teams { get; set; }

		public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=efcore;User Id=sa;Password=ragh2404;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team { TeamId = 1, Name = "CSK", CreateDate = DateTime.UtcNow },
        new Team { TeamId = 2, Name = "LSG", CreateDate = DateTime.UtcNow },
        new Team { TeamId = 3, Name = "MI", CreateDate = DateTime.UtcNow });
        }



    }
}

