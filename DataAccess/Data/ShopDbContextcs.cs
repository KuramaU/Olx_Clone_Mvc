using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data
{
    public class ShopDbContextcs: IdentityDbContext<User>
    {
        public ShopDbContextcs(DbContextOptions options): base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //base.OnConfiguring(optionsBuilder);
            string con = "Server=tcp:mybagserver.database.windows.net,1433;Initial Catalog=mybag_db;Persist Security Info=False;User ID=Lubomyr;Password=Qwerty@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(con);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category { Id = 1,Name="Electronics"},
                new Category { Id = 2,Name="Sport"},
                new Category { Id = 3,Name="Fashoin"},
                new Category { Id = 4,Name="Home & Garden"},
                new Category { Id = 5,Name="Toys & Hobbies"},
                new Category { Id = 6,Name="Transport"},
                new Category { Id = 7,Name="Art"},
                new Category { Id = 8,Name="Musical Instuments"},
            });
            modelBuilder.Entity<Product>().HasData(new[]
          {
            new Product() { Id = 1, Name = "iPhone 13 ", Price=37600,  CategoryId=1, ImageUrl="https://image.ceneostatic.pl/data/products/97863463/i-apple-iphone-13-128gb-polnoc.jpg"  },
            new Product() { Id = 2, Name = "Nike Monarh" , Price=2600, CategoryId=3, ImageUrl="https://m.media-amazon.com/images/I/61h1ijknqhL._AC_SL1179_.jpg" },
            new Product() {Id = 3, Name = "Shovel" , Price=2000, CategoryId=4, ImageUrl="https://dedra.pl/eng_pl_Sand-shovel-with-metal-shaft-PCV-handle-26346_1.webp"},
            new Product() { Id = 4, Name = "Yoyo", Price=500,CategoryId=5, ImageUrl="https://a.allegroimg.com/original/11607f/4b5e2f7b48ae92e420b90510ce2f/Magic-Yoyo-Y03-Profesjonalne-Yoyo-High-sp"}

            });
        }
        //---data collection
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
       
    }
}
