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

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPhoto> CompanyPhotos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopReview> ShopReviews { get; set; }
        public DbSet<CompanyReview> CompanyReviews { get; set; }
        public DbSet<ShopPhoto> ShopPhotos { get; set; }
        public DbSet<ReviewPhoto> ReviewPhotos { get; set; }
    }
}
