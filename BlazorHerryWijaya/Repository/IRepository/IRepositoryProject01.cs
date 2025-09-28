using BlazorHerryWijaya.Components.Project01;

namespace BlazorHerryWijaya.Repository.IRepository
{
    public interface IRepositoryProject01
    {




        public Task<List<Company>> GetAllCompany();
        public Task<List<Product>> GetAllProduct();
        public Task CreateCompany(Company company);
        public Task CreateProduct(Product product);
        public Task AddProductToInventory(AddCompanyInventoryViewModel viewModel);
    }
}
