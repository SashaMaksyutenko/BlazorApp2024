using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorApp1.Data;

namespace BlazorApp1.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category obj);
		public Task<Category> UpdateAsync(Category obj);
		public Task<bool> DeleteAsync(int id);
		public Task<Category> GetAsync(int id);
		public Task<IEnumerable<Category>> GetAllAsync();
    }
}
