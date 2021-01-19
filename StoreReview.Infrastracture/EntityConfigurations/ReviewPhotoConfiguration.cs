using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class ReviewPhotoConfiguration : IEntityTypeConfiguration<ReviewPhoto>
    {

        public void Configure(EntityTypeBuilder<ReviewPhoto> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(p => p.Review).WithMany(x=>x.Photos);
        }
    }
}
