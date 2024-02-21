using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopDb
{
    public static class DbInitializer
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new City[]
               {
                 new City()
                {
                    Id = 1,
                    Name = "Warshawa",
                    CountryId = 2,
                    
                },
                new City()
                {
                    Id = 2,
                    Name = "Rivne",
                    CountryId = 1,
                    
                },
                 new City()
                {
                   Id = 3,
                    Name = "Washington",
                    CountryId = 3,
                }
               });
        }
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
               {
                 new Country()
                {
                    Id = 1,
                    Name = "Ukraine",


                },
                new Country()
                {
                    Id = 2,
                    Name = "Poland",
                   
                },
                 new Country()
                {
                   Id = 3,
                    Name = "USA",
                }
               });
        }
        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop[]
               {
                 new Shop()
                {
                    Id = 1,
                    Name = "ATB",
                    ParkingArea = 1,
                    Address = "Soborna26",
                    CityId = 1,
                },
                new Shop()
                {
                    Id = 2,
                    Name = "Epicentr",
                    ParkingArea = 2,
                    Address = "StevanaBanderu4",
                    CityId = 2,
                },
                 new Shop()
                {
                   Id = 3,
                    Name = "Ikea",
                    ParkingArea = 3,
                    Address = "cuntralna7",
                    CityId = 3,
                }
               });
        }
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
               {
                 new Product()
                {
                    Id = 1,
                    Name = "Milk",
                    Price = 40,
                    discount = 5,
                    quantiti = 28,
                    CategoryId = 1,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Bread",
                    Price = 30,
                    discount = 2,
                    quantiti = 34,
                    CategoryId = 2,
                },
                 new Product()
                {
                   Id = 3,
                    Name = "apple",
                    Price =70,
                    discount = 6,
                    quantiti = 64,
                    CategoryId = 3,
                 }
               });
        }
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
               {
                 new Category()
                {
                    Id = 1,
                    Name = "dairy",
                    
                },
                new Category()
                {
                    Id = 2,
                    Name = "food",
                },
                 new Category()
                {
                   Id = 3,
                    Name = "fruit",
                 }
               });
        }
        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(new Worker[]
               {
                 new Worker()
                {
                    Id = 1,
                    Name = "Daivd",
                    SurName = "Ivanov",
                    Salary = 12000,
                    Email = "David@email.com",
                    PhoneNumber = "12345678",
                    PositionId = 1,
                     ShopId = 1,
                },
                new Worker()
                {
                    Id = 2,
                    Name = "Ivan",
                    SurName = "Bondarenko",
                    Salary = 9000,
                    Email = "Ivan@email.com",
                    PhoneNumber = "75462746",
                    PositionId = 2,
                    ShopId = 2,
                },
                 new Worker()
                {
                   Id = 3,
                    Name = "Vitya",
                    SurName = "Ivanenko",
                    Salary = 11000,
                    Email = "Vitya@email.com",
                    PhoneNumber = "26584731",
                    PositionId = 3,
                    ShopId = 3,
                 }
               }) ;
        }
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position[]
               {
                 new Position()
                {
                    Id = 1,
                    Name = "Manager",
                    
                },
                new Position()
                {
                    Id = 2,
                    Name = "cashier",
                },
                 new Position()
                {
                   Id = 3,
                    Name = "guardian",
                 }
               });
        }

    }
}
