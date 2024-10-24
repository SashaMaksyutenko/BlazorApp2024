using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp2024.Data;
namespace BlazorApp2024.Repository.IRepository
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
