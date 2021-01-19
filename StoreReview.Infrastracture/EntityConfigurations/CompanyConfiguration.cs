using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreReview.Core.Domain;

namespace StoreReivew.Infrastracture.EntityConfigurations
{
    class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(3000);
            builder.Property(p => p.Phone).HasMaxLength(20);

            builder.HasMany(k => k.Reviews).WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
