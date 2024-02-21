using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDb
{
    public class City
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; } //not null
        public ICollection<Shop> Shops { get; set; } //null

    } //2
    public class Shop
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        public int? ParkingArea { get; set; }


        public City City { get; set; }
        public int CityId { get; set; } //not null
        public ICollection<Product> Products { get; set; } //null
        public ICollection<Worker> Workers { get; set; } //null

    } //3
    public class Country
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }//null
    } //1
    public class Product //5
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float discount { get; set; }
        public int quantiti { get; set; }
        public bool isInStock { get; set; }


        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Shop> Shops { get; set; }

    }
    public class Category //4
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }


        public ICollection<Product> Products { get; set; }
    }
    public class Worker //7
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string SurName { get; set; }
        public decimal Salary { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string PhoneNumber { get; set; }


        public Shop Shop { get; set; }
        public int ShopId { get; set; }

        public Position Position { get; set; }
        public int PositionId { get; set; }

    }
    public class Position //6
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }


    public class ShopDbContex : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9K9OL7\SQLEXPRESS;
                                        Initial Catalog = ShopDb;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //one to one
            modelBuilder.Entity<City>()
               .HasOne(f => f.Country)
               .WithMany(a => a.Cities)
               .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Shop>()
              .HasOne(f => f.City)
              .WithMany(a => a.Shops)
              .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<Worker>()
              .HasOne(f => f.Shop)
              .WithMany(a => a.Workers)
              .HasForeignKey(a => a.ShopId);

            modelBuilder.Entity<Worker>()
              .HasOne(f => f.Position)
              .WithMany(a => a.Workers)
              .HasForeignKey(a => a.PositionId);

            modelBuilder.Entity<Product>()
             .HasOne(f => f.Category)
             .WithMany(a => a.Products)
             .HasForeignKey(a => a.CategoryId);

            //many to many
            modelBuilder.Entity<Product>()
                .HasMany(f => f.Shops)
                .WithMany(c => c.Products);

            modelBuilder.Entity<Shop>()
               .HasMany(f => f.Products)
               .WithMany(c => c.Shops);




            modelBuilder.SeedCountries(); 
            modelBuilder.SeedCities();
            modelBuilder.SeedCategories();
            modelBuilder.SeedPositions();
            modelBuilder.SeedShops();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedProducts();





        }
    }
}
