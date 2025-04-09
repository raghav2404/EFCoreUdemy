using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkCore.Data.Configurations
{
    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(new Coach
            { Id = 1, Name = "Dravid" },
            new Coach{ Id = 2,Name="Gambhir"},
            new Coach { Id = 3 , Name="Sachin"});


          }
    }



}



