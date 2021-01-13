using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(100);

            //builder.HasMany<User>()
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
