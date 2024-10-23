using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp2024.Data;
namespace BlazorApp2024.Repository.IRepository
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