using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MuscleFellow.Models;

namespace MuscleFellow.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        
        Task<Guid> AddAsync(Product product);
        
        Task DeleteAsync(Guid productID);
        
        Task<Product> GetAsync(Guid productID);
        
        Task<IEnumerable<Product>> GetProductsAsync(string filter, int pageSize, int pageCount);
        
        Task<IEnumerable<Product>> GetPopularProductsAsync(int count);
        
        Task<Guid> UpdateAsync(Product product);
    }
}
