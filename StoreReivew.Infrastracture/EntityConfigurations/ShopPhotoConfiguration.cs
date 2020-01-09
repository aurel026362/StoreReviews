using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class ShopPhotoConfiguration : IEntityTypeConfiguration<ShopPhoto>
    {

        public void Configure(EntityTypeBuilder<ShopPhoto> builder)
        {
            builder.ToTable("ShopPhotos");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(k => k.Shop).WithMany(p => p.Photos);
        }
    }
}
