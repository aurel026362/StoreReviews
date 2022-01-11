using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReview.Infrastracture.EntityConfigurations.Files
{
    class CompanyFileConfiguration : IEntityTypeConfiguration<CompanyFile>
    {

        public void Configure(EntityTypeBuilder<CompanyFile> builder)
        {
            builder.ToTable("CompanyFiles");
            builder.Ignore(p => p.Id);

            builder.HasKey(k => new
            {
                k.FileId,
                k.CompanyId
            });
        }
    }
}