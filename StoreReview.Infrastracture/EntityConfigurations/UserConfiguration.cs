using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(100);
            //builder.Property(p => p.RoleId).IsRequired();
            //builder.HasOne(key => key.Role).WithMany(p => p.Users)
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
