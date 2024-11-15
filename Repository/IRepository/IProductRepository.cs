using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorApp1.Data;

namespace BlazorApp1.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> CreateAsync(Product obj);
		public Task<Product> UpdateAsync(Product obj);
		public Task<bool> DeleteAsync(int id);
		public Task<Product> GetAsync(int id);
		public Task<IEnumerable<Product>> GetAllAsync();
    }
}
