using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreReview.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreReivew.Infrastracture.Data
{
    public class StoreReviewDbContext : IdentityDbContext<User, Role, long>
    {
        public StoreReviewDbContext()
        {

        }
        public StoreReviewDbContext(DbContextOptions<StoreReviewDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyFile> CompanyPhotos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopReview> ShopReviews { get; set; }
        public DbSet<CompanyReview> CompanyReviews { get; set; }
        public DbSet<ShopFile> ShopPhotos { get; set; }
        public DbSet<File> Files { get; set; }
    }
}
