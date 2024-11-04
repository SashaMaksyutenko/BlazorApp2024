using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp2024.Data;

namespace BlazorApp2024.Repository.IRepository
{
    public interface IOrderRepository
    {
        public Task<OrderHeader> CreateAsync(OrderHeader orderHeader);
        public Task<OrderHeader> GetAsync(int id);
        public Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId=null);
        public Task<OrderHeader> UpdateStatusAsync(int orderId, string status);
    }
}