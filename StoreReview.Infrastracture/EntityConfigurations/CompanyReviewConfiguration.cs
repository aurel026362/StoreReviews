using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class CompanyReviewConfiguration : IEntityTypeConfiguration<CompanyReview>
    {

        public void Configure(EntityTypeBuilder<CompanyReview> builder)
        {
            builder.ToTable("CompanyReviews");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(2000);
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Ratting).IsRequired();
            builder.HasOne(p => p.User).WithMany();
            builder.HasMany(p => p.Replies);
            builder.HasOne(p => p.Company).WithMany(x => x.Reviews);
        }
    }
}
