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
        public async Task<IEnumerable<Company>> GetAll()
        {
            return await dbContext.Company
             //   .Include(x=>x.Inventories)
              //  .ThenInclude(x=>x.Company)
                .Include(x=>x.Inventories)
                .ThenInclude(x=>x.Product)
               .AsNoTracking()
                .ToListAsync();

        }
    }
}
