using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Data;

namespace Test2.Configuration.Enties
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employ>
    {
        public void Configure(EntityTypeBuilder<Employ> builder)
        {
                var hash =  new PasswordHasher<Employ>();

            builder.HasData(
     
                 new Employ
                 {
                     Id = "8b54618f-61e6-4a76-ba64-be6209bbff00",
                     Email = "mohameeda326@gmail.com",
                     NormalizedEmail = "MOHAMEEDA326@GMAIL.COM",
                     NormalizedUserName = "MOHAMEEDA326@GMAIL.COM",
                     UserName = "mohameeda326@gmail.com",
                     name = "Mohammed",
                     
                     lastname = "ali raheem",
                     PasswordHash= hash.HashPassword(null, "Mohamad1122@"),
                     EmailConfirmed = true,
                 },

                   new Employ
                   {
                       Id = "363cfe19-710f-4035-8ffa-0ee5f7da077a",
                       Email = "test@test.com",
                       NormalizedEmail = "TEST@TEST.COM",
                       NormalizedUserName = "TEST@TEST.COM",
                       UserName = "test@test.com",
                       name = "test",
                       lastname = "uest",
                       PasswordHash = hash.HashPassword(null, "Mohamad1122@")          ,
                       EmailConfirmed = true,

                   }

                );
        }
    }
}