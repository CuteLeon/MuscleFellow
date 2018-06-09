using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuscleFellow.Data.Interfaces;
using MuscleFellow.Models;
using Microsoft.EntityFrameworkCore;

namespace MuscleFellow.Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private MuscleFellowDbContext _dbContext = null;

        public BrandRepository(MuscleFellowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加生产商
        /// </summary>
        /// <param name="brand">生产商</param>
        /// <returns></returns>
        public async Task<int> AddAsync(Brand brand)
        {
            if (null == brand)
                return -1;
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return brand.BrandID;
        }

        /// <summary>
        /// 删除生产商
        /// </summary>
        /// <param name="brandID">生产商ID</param>
        /// <returns></returns>
        public async Task DeleteAsync(int brandID)
        {
            var brand = await _dbContext.Brands
                .SingleOrDefaultAsync(b => b.BrandID == brandID);

            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 获取生产商
        /// </summary>
        /// <param name="brandID">生产商ID</param>
        /// <returns>生产商</returns>
        public async Task<Brand> GetAsync(int brandID)
        {
            return await _dbContext.Brands.Where(b => b.BrandID == brandID).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 获取生产商总数
        /// </summary>
        /// <returns>生产商总数</returns>
        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Brands.CountAsync();
        }

        /// <summary>
        /// 获取所有生产商
        /// </summary>
        /// <returns>生产商列表</returns>
        public async Task<List<Brand>> GetAllAsync()
        {
            return await _dbContext.Brands.ToListAsync();
        }

        /// <summary>
        /// 获取商品枚举
        /// </summary>
        /// <param name="brandId">生产商ID</param>
        /// <param name="filter">过滤</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsAsync(int brandID, string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Products.Where
                (p => p.BrandID == brandID && (String.IsNullOrEmpty(filter) ||
                p.ProductName.Contains(filter) || p.Description.Contains(filter)))
                .Select(p => new { Product = p, })
                .Skip(pageSize * pageCount)
                .Take(pageSize)
                .ToListAsync();

            return results.Select(p => p.Product);
        }

        /// <summary>
        /// 更新生产商信息
        /// </summary>
        /// <param name="brand">生产商</param>
        /// <returns></returns>
        public async Task UpdateAsync(Brand brand)
        {
            if (null == brand)
                return;
            _dbContext.Brands.Update(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
