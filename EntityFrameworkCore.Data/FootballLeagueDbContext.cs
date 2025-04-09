using System.Reflection;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<League> Leagues { get; set; }


        public FootballLeagueDbContext(DbContextOptions<FootballLeagueDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=efcore;User Id=sa;Password=ragh2404;TrustServerCertificate=True;"

                , optionsBuilder =>
                { optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    optionsBuilder.CommandTimeout(30);
                    optionsBuilder.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5),errorNumbersToAdd:null);
      


                })
               .UseLazyLoadingProxies()
               // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseDomainModel>()
                .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

            foreach(var entry in entries)
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
                entry.Entity.ModifiedBy = "user 1";

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "sample user 1";
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
    

    public class FootballLeagueDbContextFactory : IDesignTimeDbContextFactory<FootballLeagueDbContext>
    {
        public FootballLeagueDbContext CreateDbContext(string[] args)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

           // var dbPath = Path.Combine(path, configuration.GetConnectionString("ConnectionString"));

            var optionsBuilder = new DbContextOptionsBuilder<FootballLeagueDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=efcore;User Id=sa;Password=ragh2404;TrustServerCertificate=True;");

            return new FootballLeagueDbContext(optionsBuilder.Options);
        }



    }
}

