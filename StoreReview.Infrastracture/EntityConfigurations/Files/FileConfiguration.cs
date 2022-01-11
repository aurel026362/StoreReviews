using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations.Files
{
    class FileConfiguration : IEntityTypeConfiguration<File>
    {

        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("Files");

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Extension).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Path).IsRequired();

            //builder.Ignore(x => x.CreatedBy);
            //builder.Ignore(x => x.UpdatedBy);
        }
    }
}