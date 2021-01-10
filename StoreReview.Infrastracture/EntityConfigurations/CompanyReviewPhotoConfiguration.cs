using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class CompanyReviewPhotoConfiguration : IEntityTypeConfiguration<CompanyReviewPhoto>
    {

        public void Configure(EntityTypeBuilder<CompanyReviewPhoto> builder)
        {
            builder.ToTable("CompanyReviewPhotos");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(p => p.CompanyReview).WithMany(x=>x.Photos);
        }
    }
}
