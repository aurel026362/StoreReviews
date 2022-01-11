using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations.Files
{
    class ReviewFileConfiguration : IEntityTypeConfiguration<ReviewFile>
    {

        public void Configure(EntityTypeBuilder<ReviewFile> builder)
        {
            builder.ToTable("ReviewFiles");
            builder.Ignore(p => p.Id);

            builder.HasKey(k => new
            {
                k.FileId,
                k.ReviewId
            });
        }
    }
}