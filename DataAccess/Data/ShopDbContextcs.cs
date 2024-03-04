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
            string con = "Server=tcp:azurebagserver.database.windows.net,1433;Initial Catalog=BagShop_db1;Persist Security Info=False;User ID=lubomyr;Password=Qwerty@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(con);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<District>().HasData(new[] 
            { 
            new District {Id = 1, Name="Aвтономна Республiка Крим"},
             new District {Id = 2, Name="Вінницька"},
             new District {Id = 3, Name="Волинська"},
             new District {Id = 4, Name="Днiпропетровська"},
             new District {Id = 5, Name="Донецька"},
             new District {Id = 6, Name="Житомирська"},
              new District {Id = 7, Name="Закарпатська"},
             new District{Id = 8, Name="Запорiзька"},
             new District {Id = 9, Name="Iвано-Франкiвська"},
              new District {Id = 10, Name="Київська"},
             new District {Id = 11, Name="Кiровоградська"},
             new District {Id = 12, Name="Луганська"},
             new District {Id = 13, Name="Львiвська"},
              new District {Id = 14, Name="Миколаївська"},
             new District {Id = 15, Name="Одеська"},
             new District {Id = 16, Name="Полтавська"},
              new District {Id = 17, Name="Рiвненська"},
             new District{Id = 18, Name="Сумська"},
             new District{Id = 19, Name="Тернопiльська"},
              new District {Id = 20, Name="Харкiвська"},
             new District {Id = 21, Name="Херсонська"},
             new District {Id = 22, Name="Хмельницька"},
             new District {Id = 23, Name="Черкаська"},
              new District {Id = 24, Name="Чернiвецька"},
                  new District{Id = 25, Name="Чернiгiвська"},
            });


            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category { Id = 1,Name="Електроніка"},
                new Category { Id = 2,Name="Хобі та спорт"},
                new Category { Id = 3,Name="Мода і стиль"},
                new Category { Id = 4,Name="Дім і сад"},
                new Category { Id = 5,Name="Дитячі товари"},
                new Category { Id = 6,Name="Транспорт"},
                new Category { Id = 7,Name="Нерухомість"},
                new Category { Id = 8,Name="Будівництво та ремонт"},
               
                new Category { Id = 9,Name="Робота"},
                new Category { Id = 10,Name="Послуги"},
                new Category { Id = 11,Name="Віддам безкоштовно"},
                  new Category { Id = 12,Name="Оренда та прокат"},
            });
            modelBuilder.Entity<Product>().HasData(new[]
          {
            new Product() { Id = 1, Name = "iPhone 13 ", Price=37600, D_VIP=DateTime.Today.AddDays(-8),   CategoryId=1, DistrictId=17,CreatedDate=DateTime.Today, ImageUrl="https://image.ceneostatic.pl/data/products/97863463/i-apple-iphone-13-128gb-polnoc.jpg"  },
            new Product() { Id = 2, Name = "Nike Monarh" , Price=2600,D_VIP=DateTime.Today.AddDays(-2) ,CategoryId=3,  DistrictId=17, CreatedDate=DateTime.Today ,ImageUrl="https://m.media-amazon.com/images/I/61h1ijknqhL._AC_SL1179_.jpg" },
            new Product() {Id = 3, Name = "Shovel" , Price=2000,D_VIP=DateTime.Today ,CategoryId=4, DistrictId=17, CreatedDate=DateTime.Today, ImageUrl="https://dedra.pl/eng_pl_Sand-shovel-with-metal-shaft-PCV-handle-26346_1.webp"},
            new Product() { Id = 4, Name = "Yoyo", Price=500,D_VIP=DateTime.Today.AddDays(-1),CategoryId=5,  DistrictId=17, CreatedDate=DateTime.Today ,ImageUrl="https://a.allegroimg.com/original/11607f/4b5e2f7b48ae92e420b90510ce2f/Magic-Yoyo-Y03-Profesjonalne-Yoyo-High-sp"}

            });
        }
        //---data collection
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
       public DbSet<District> Districts { get; set; }

    }
}
