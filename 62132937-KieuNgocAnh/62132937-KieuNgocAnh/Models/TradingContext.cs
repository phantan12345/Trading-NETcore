using _62132937_KieuNgocAnh.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace _62132937_KieuNgocAnh.Models
{
    public class TradingContext : DbContext
    {
        public TradingContext()
        {

        }
        public TradingContext(DbContextOptions<TradingContext> options) : base(options) { }

        public virtual DbSet<User_62132937> Users { get; set; } = null!;
        public virtual DbSet<Product_62132937> Products { get; set; } = null!;
        public virtual DbSet<Role_62132937> Roles { get; set; } = null!;
        public virtual DbSet<Category_62132937> Categorys { get; set; } = null!;
        public virtual DbSet<Order_62132937> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail_62132937> Orderdetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Products");

            });


            modelBuilder.Entity<User_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Users");

            });


            modelBuilder.Entity<Role_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Roles");

            });


            modelBuilder.Entity<Category_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Categorys");

            });

            modelBuilder.Entity<Order_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Orders");

            });

            modelBuilder.Entity<OrderDetail_62132937>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.ToTable("Orderdetails");

            });

        }
    }
}
