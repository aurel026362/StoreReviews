using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations
{
    class ShopReviewConfiguration : IEntityTypeConfiguration<ShopReview>
    {

        public void Configure(EntityTypeBuilder<ShopReview> builder)
        {
            builder.HasOne(k => k.Shop).WithMany(x=>x.Reviews)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
