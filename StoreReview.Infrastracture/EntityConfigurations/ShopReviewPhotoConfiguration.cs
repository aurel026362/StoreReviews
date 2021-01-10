using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class ShopReviewPhotoConfiguration : IEntityTypeConfiguration<ShopReviewPhoto>
    {

        public void Configure(EntityTypeBuilder<ShopReviewPhoto> builder)
        {
            builder.ToTable("ShopReviewPhotos");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(p => p.ShopReview).WithMany(x => x.Photos);
        }
    }
}
