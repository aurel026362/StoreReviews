using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {

        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Shops");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Address).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Description).HasMaxLength(3000);
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.HasOne(k => k.Company).WithMany(p => p.Shops);

            builder.HasMany(k => k.Reviews).WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
