using BlazorHerryWijaya.Components.Project01;

namespace BlazorHerryWijaya.Repository.IRepository
{
    public interface IRepositoryProject01
    {




        public Task<IEnumerable<Company>> GetAll();
    }
}
