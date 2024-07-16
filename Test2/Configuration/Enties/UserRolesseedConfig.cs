using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test2.Configuration.Enties
{
    internal class UserRolesseedConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(

                new IdentityUserRole<string>
                {
                    RoleId = "33e6a5bb-209a-49a4-a39d-783ffed4efb0",
                    UserId = "8b54618f-61e6-4a76-ba64-be6209bbff00"
                },
                
                new IdentityUserRole<string>
                {
                    RoleId = "e2c4e32b-9c45-41bb-8f7a-74ca17e00361",
                    UserId = "363cfe19-710f-4035-8ffa-0ee5f7da077a"
                }
                );
        }
    }
}