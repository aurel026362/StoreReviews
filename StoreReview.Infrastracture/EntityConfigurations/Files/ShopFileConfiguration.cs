using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations.Files
{
    class ShopFileConfiguration : IEntityTypeConfiguration<ShopFile>
    {

        public void Configure(EntityTypeBuilder<ShopFile> builder)
        {
            builder.ToTable("ShopFiles");
            builder.Ignore(p => p.Id);

            builder.HasKey(k => new
            {
                k.FileId,
                k.ShopId
            });
        }
    }
}