using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations
{
    class CompanyReviewConfigurationusing: IEntityTypeConfiguration<CompanyReview>
        {

            public void Configure(EntityTypeBuilder<CompanyReview> builder)
            {
                builder.HasOne(k => k.Company).WithMany(x => x.Reviews)
                .OnDelete(DeleteBehavior.NoAction);
            }
        }
    }
