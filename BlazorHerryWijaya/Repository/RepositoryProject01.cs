using BlazorHerryWijaya.Components.Project01;
using BlazorHerryWijaya.Data;
using BlazorHerryWijaya.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BlazorHerryWijaya.Repository
{
    public class RepositoryProject01 : IRepositoryProject01
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryProject01(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<CompanyInventoryDto>> GetInventoryByCompanyId(int companyId)
        {
            return await dbContext.CompanyInventory
                .AsNoTracking()
                .Where(x => x.CompanyId == companyId)
                .Select(x => new CompanyInventoryDto
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    StockQuantity = x.StockQuantity
                })
                .ToListAsync();
        }
        //public async Task<List<CompanyInventoryDto>> GetInventoryByCompanyId(int companyId)
        //{
        //    return await dbContext.CompanyInventory
        //        .Where(x=>x.CompanyId==companyId)
        //        .Include(x=>x.Company)
        //    .Include(i => i.Product)
        //.AsNoTracking()
        //.Select(x=>new CompanyInventoryDto
        //{
        //    Id=x.Id,
        //    ProductId=x.ProductId,
        //    ProductName=x.Product.Name,
        //    StockQuantity=x.StockQuantity,
        //})
        //        .ToListAsync();
        //}
        public async Task<CompanyDto?> GetCompanyById(int id)
        {
            return await dbContext.Company
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(x => new CompanyDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Inventories = x.Inventories
                        .Select(i => new CompanyInventoryDto
                        {
                            Id = i.Id,
                            ProductId = i.ProductId,
                            ProductName = i.Product.Name,
                            StockQuantity = i.StockQuantity
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }
        //public async Task<CompanyDto?> GetCompanyById(int id)
        //{
        //    return await dbContext.Company
        //        .Include(c => c.Inventories)
        //    .ThenInclude(i => i.Product)

        //.Select(x=>new CompanyDto
        //{
        //    Id=x.Id,
        //    Name=x.Name,
        //    Inventories = x.Inventories
        //        .Select(i => new CompanyInventoryDto
        //        {
        //            Id = i.Id,
        //            ProductId = i.ProductId,
        //            ProductName = i.Product.Name,
        //            StockQuantity = i.StockQuantity
        //        }).ToList()
        //})
        //    .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        public async Task AddProductToInventory(CompanyInventoryDtoSave companyInventory)
        {
            //var productInventory = new CompanyInventory()
            //{
            //    CompanyId = viewModel.CompanyId,
            //    ProductId=viewModel.ProductId,
            //    StockQuantity=viewModel.Quantity,
            //};
            var companyInventoryDb = new CompanyInventory
            {
                CompanyId=companyInventory.CompanyId,
                ProductId = companyInventory.ProductId,
                StockQuantity = companyInventory.StockQuantity,
            };
            await dbContext.CompanyInventory.AddAsync(companyInventoryDb);
            await dbContext.SaveChangesAsync();

        }

        public async Task CreateCompany(CompanyDtoSave company)
        {
            var companyDb = new Company
            {
                Name=company.Name
            };
           await dbContext.Company.AddAsync(companyDb);
            await dbContext.SaveChangesAsync();
        }
        public async Task CreateProduct(ProductDtoSave product)
        {
            var productDb = new Product
            {
                Name= product.Name,
            };
           await dbContext.Product.AddAsync(productDb);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<CompanyDto>> GetAllCompany()
        {
            return await dbContext.Company
                .AsNoTracking()
                .Select(x => new CompanyDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Inventories = x.Inventories.Select(i => new CompanyInventoryDto
                    {
                        Id = i.Id,
                        ProductId = i.ProductId,
                        ProductName = i.Product.Name,
                        StockQuantity = i.StockQuantity
                    }).ToList()
                })
                .ToListAsync();
        }

        //public async Task<List<CompanyDto>> GetAllCompany()
        //{
        //    return await dbContext.Company
        //     //   .Include(x=>x.Inventories)
        //      //  .ThenInclude(x=>x.Company)
        //        .Include(x=>x.Inventories)
        //        .ThenInclude(x=>x.Product)
        //       .AsNoTracking()
        //       .Select(x=>new CompanyDto
        //       {
        //           Id=x.Id,
        //           Name=x.Name,
        //           Inventories = x.Inventories.Select(i => new CompanyInventoryDto
        //           {
        //               Id = i.Id,
        //               ProductId = i.ProductId,
        //               ProductName = i.Product.Name,
        //               StockQuantity = i.StockQuantity
        //           }).ToList()
        //       })
        //        .ToListAsync();

        //}
     
        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await dbContext.Product

               .AsNoTracking()
               .Select(x=>new ProductDto
               {
                   Id = x.Id,
                   Name = x.Name
               })
                .ToListAsync();

        }
    }
}
