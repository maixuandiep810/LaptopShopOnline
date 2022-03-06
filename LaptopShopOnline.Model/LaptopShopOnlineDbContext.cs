using LaptopShopOnline.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LaptopShopOnline.Model
{

    public partial class LaptopShopOnlineDbContext : DbContext
    {

        private readonly ILogger<LaptopShopOnlineDbContext> _logger;

        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public LaptopShopOnlineDbContext()
        {
        }

        public LaptopShopOnlineDbContext(DbContextOptions options, ILogger<LaptopShopOnlineDbContext> logger) : base(options)
        {
            _logger = logger;
            _logger.LogInformation("Starting to create LaptopShopOnlineDbContext...");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging();
        }
        public virtual DbSet<NewsCategory> NewsCategory { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        //public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            //  CREDENTIAL
            modelBuilder.Entity<Credential>().HasKey(p => new { p.UserGroupId, p.RoleId });

            modelBuilder.Entity<Credential>()
                .HasOne(e => e.UserGroup)
                .WithMany(e => e.Credentials)
                .HasForeignKey(e => e.UserGroupId);
            modelBuilder.Entity<Credential>()
                .HasOne(e => e.Role)
                .WithMany(e => e.Credentials)
                .HasForeignKey(e => e.RoleId);



            ////  LAYOUT
            //modelBuilder.Entity<NewsCategory>()
            //    .Property(e => e.MetaTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<News>()
            //    .Property(e => e.MetaTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<News>()
            //    .HasOne(e => e.NewsCategory)
            //    .WithMany(e => e.News)
            //    .HasForeignKey(e => e.NewsCategoryId);

            //modelBuilder.Entity<Feedback>()
            //    .Property(e => e.Phone)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Feedback>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);




            //  ORDER
            //modelBuilder.Entity<Order>()
            //    .Property(e => e.ShipEmail)
            //    .IsUnicode(false);



            //  ORDER DETAIL
            modelBuilder.Entity<OrderDetail>()
               .Property(e => e.Price)
               .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>().HasKey(p => new { p.ProductId, p.OrderId });
            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.Product)
                .WithMany()
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.NoAction);



            //  PRODUCT
            modelBuilder.Entity<Product>()
               .Property(e => e.Price)
               .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
               .Property(e => e.PromotionPrice)
               .HasPrecision(18, 0);

            //modelBuilder.Entity<Product>().Ignore(e => e.Image);
            //modelBuilder.Entity<Product>().Ignore(e => e.Sub1Image);
            //modelBuilder.Entity<Product>().Ignore(e => e.Sub2Image);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.ProductCategory)
                .WithMany(e => e.Product)
                .HasForeignKey(e => e.ProductCategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Shop)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.ShopId);



            // ROLE
            //modelBuilder.Entity<Role>()
            //    .Property(e => e.Id)
            //    .IsUnicode(false);



            //  SHOP



            // USER
            modelBuilder.Entity<User>()
                .Property(e => e.UserGroupId)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasOne(e => e.UserGroup)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.UserGroupId);

            modelBuilder.Entity<User>()
                .HasOne(e => e.Shop)
                .WithOne(e => e.Seller)
                .HasForeignKey<Shop>(e => e.SellerId);



            // USERGROUP
            modelBuilder.Entity<UserGroup>()
                .Property(e => e.Id)
                .IsUnicode(false);
        }
    }
}
