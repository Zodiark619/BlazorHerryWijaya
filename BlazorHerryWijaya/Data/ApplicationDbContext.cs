using BlazorHerryWijaya.Components.Project01;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorHerryWijaya.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
    public DbSet<Product> Product { get; set; }
    public DbSet<CompanyInventory> CompanyInventory { get; set; }
    public DbSet<Company> Company { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var product=new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name="Tomato Red"
                },
                new Product
                {
                    Id = 2,
                    Name="Apple Red"
                },
                new Product
                {
                    Id = 3,
                    Name="Banana Yellow"
                },
                new Product
                {
                    Id = 4,
                    Name="Apple Green"
                },
                new Product
                {
                    Id = 5,
                    Name="Tomato Dark Red"
                },
            };
            var inventory = new List<CompanyInventory>()
            {
                new CompanyInventory
                {
                    Id=1,
                    CompanyId=1,
                    ProductId=1,
                    StockQuantity=15,
                },
                new CompanyInventory
                {
                    Id=2,
                    CompanyId=1,
                    ProductId=2,
                    StockQuantity=25,
                },
                new CompanyInventory
                {
                    Id=3,
                    CompanyId=1,
                    ProductId=5,
                    StockQuantity=115,
                },
                ////
                ///
                  new CompanyInventory
                {
                    Id=4,
                    CompanyId=2,
                    ProductId=1,
                    StockQuantity=215,
                },
                    new CompanyInventory
                {
                    Id=5,
                    CompanyId=2,
                    ProductId=3,
                    StockQuantity=315,
                },
                      new CompanyInventory
                {
                    Id=6,
                    CompanyId=2,
                    ProductId=4,
                    StockQuantity=415,
                },
                      /////
                        new CompanyInventory
                {
                    Id=7,
                    CompanyId=3,
                    ProductId=2,
                    StockQuantity=25,
                },
                          new CompanyInventory
                {
                    Id=8,
                    CompanyId=3,
                    ProductId=4,
                    StockQuantity=46,
                },
                            new CompanyInventory
                {
                    Id=9,
                    CompanyId=3,
                    ProductId=5,
                    StockQuantity=77,
                },
            };
            var company = new List<Company>()
            {
                new Company
                {
                    Id=1,
                    Name="PT Jaya Kusuma"
                },
                new Company
                {
                    Id=2,
                    Name="Sehat Swadaya Tbk."
                },
                new Company
                {
                    Id=3,
                    Name="PT Makmur Bersama"
                },
            };



            builder.Entity<Product>().HasData(product);
            builder.Entity<Company>().HasData(company);
            builder.Entity<CompanyInventory>().HasData(inventory);
        }
    }

}
