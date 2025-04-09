using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> leagueBuilder)
        {
            //this predicate will be applied to all
            //queries targeting this entity type - global query filter
            leagueBuilder.HasQueryFilter(x => x.IsDeleted == false);
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

