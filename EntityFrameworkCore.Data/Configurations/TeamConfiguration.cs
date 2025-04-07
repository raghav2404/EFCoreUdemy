using System.Reflection.Emit;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> teamBuilder)
        {
            teamBuilder.Property(x => x.Name).IsRequired();
            teamBuilder.HasIndex(x => x.Name).IsUnique();
            teamBuilder
                .HasMany(m => m.HomeMatches)
                .WithOne(x => x.HomeTeam)
                .HasForeignKey(X => X.HomeTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            teamBuilder
                .HasMany(m => m.AwayMatches)
                .WithOne(x => x.AwayTeam)
                .HasForeignKey(X => X.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            teamBuilder
    .HasOne(t => t.Coach)
    .WithOne(x => x.Team)
    .IsRequired(false);


           teamBuilder.HasData(
        new Team { Id = 1, Name = "CSk", CreateDate = DateTime.UtcNow, LeagueId = 1, CoachId = 1 },
        new Team { Id = 2, Name = "LSg", CreateDate = DateTime.UtcNow, LeagueId = 1, CoachId = 2 },
        new Team { Id = 3, Name = "Mi", CreateDate = DateTime.UtcNow ,LeagueId =2,CoachId=3});
        }
    }



}



