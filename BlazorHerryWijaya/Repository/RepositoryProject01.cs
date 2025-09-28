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

        public async Task AddProductToInventory(AddCompanyInventoryViewModel viewModel)
        {
            var productInventory = new CompanyInventory()
            {
                CompanyId = viewModel.CompanyId,
                ProductId=viewModel.ProductId,
                StockQuantity=viewModel.Quantity,
            };
            await dbContext.CompanyInventory.AddAsync(productInventory);
            await dbContext.SaveChangesAsync();

        }

        public async Task CreateCompany(Company company)
        {
           await dbContext.Company.AddAsync(company);
            await dbContext.SaveChangesAsync();
        }
        public async Task CreateProduct(Product product)
        {
           await dbContext.Product.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await dbContext.Company
             //   .Include(x=>x.Inventories)
              //  .ThenInclude(x=>x.Company)
                .Include(x=>x.Inventories)
                .ThenInclude(x=>x.Product)
               .AsNoTracking()
                .ToListAsync();

        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await dbContext.Product

               .AsNoTracking()
                .ToListAsync();

        }
    }
}
