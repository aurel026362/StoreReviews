using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class CompanyPhotoConfiguration : IEntityTypeConfiguration<CompanyPhoto>
    {

        public void Configure(EntityTypeBuilder<CompanyPhoto> builder)
        {
            builder.ToTable("CompanyPhotos");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(k => k.Company).WithMany(p => p.Photos).HasForeignKey(p => p.CompanyId);
        }
    }
}
