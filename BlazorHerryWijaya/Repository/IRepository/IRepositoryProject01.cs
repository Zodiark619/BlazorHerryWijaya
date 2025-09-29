using BlazorHerryWijaya.Components.Project01;

namespace BlazorHerryWijaya.Repository.IRepository
{
    public interface IRepositoryProject01
    {




        public Task<List<CompanyDto>> GetAllCompany();
        public Task<List<ProductDto>> GetAllProduct();
        public Task CreateCompany(CompanyDtoSave company);
        public Task CreateProduct(ProductDtoSave product);
        public Task AddProductToInventory(CompanyInventoryDtoSave companyInventory);

        public Task<CompanyDto?> GetCompanyById(int id);    
        public Task<List<CompanyInventoryDto>> GetInventoryByCompanyId(int companyId);
    }
}
