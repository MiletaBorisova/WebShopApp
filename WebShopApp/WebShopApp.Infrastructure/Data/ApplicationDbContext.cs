using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShopApp.Infrastructure.Data.Entities;

namespace WebShopApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           //Database.EnsureCreated();
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PromoCode>().HasData(
                new PromoCode
                {
                    Id = 1,
                    Code = "PROMO10",
                    DiscountPercent = 10,
                    IsActive = true
                },
                new PromoCode
                {
                    Id = 2,
                    Code = "PROMO20",
                    DiscountPercent = 20,
                    IsActive = true
                }
            );
        }
    }
}
