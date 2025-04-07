using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> leagueBuilder)
        {
            leagueBuilder.HasData(

                new League
                {
                    Id = 1,
                    Name = "WPL"
                },
                new League
                {
                    Id = 2,
                    Name = "IPL"
                },
                new League
                {
                    Id = 3,
                    Name = "BIG BASH"
                }
                );
        }
    }


}

