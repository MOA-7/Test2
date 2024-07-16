using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test2.Configuration.Enties
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "33e6a5bb-209a-49a4-a39d-783ffed4efb0",
                    Name = "Admin",
                    NormalizedName = "ADMIN",

                },
                    new IdentityRole
                    {
                        Id = "e2c4e32b-9c45-41bb-8f7a-74ca17e00361",
                        Name = "User",
                        NormalizedName = "USER",

                    }




                );
        }
    }
}