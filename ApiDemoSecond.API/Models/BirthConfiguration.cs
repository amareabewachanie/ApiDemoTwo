using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiDemoSecond.API.Models
{
    public class BirthConfiguration: IEntityTypeConfiguration<Birth>
    {
        public void Configure(EntityTypeBuilder<Birth> builder)
        {
            builder.HasData(new Birth
            {
                Id=1,
                FirstName="Seed",
                MiddleName="Data",
                LastName="Populated",
                DateOfBirth=DateTime.Now,
                Address="Initial Seed"
,            });
        }
    }
   
}
