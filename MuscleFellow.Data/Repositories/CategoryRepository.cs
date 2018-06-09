using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuscleFellow.Models;
using MuscleFellow.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MuscleFellow.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private MuscleFellowDbContext _dbContext = null;

        public CategoryRepository(MuscleFellowDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public async Task<int> AddAsync(Category category)
        {
            if (null == category)
                return -1;
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category.CategoryID;
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="categoryID">分类ID</param>
        /// <returns></returns>
        public async Task DeleteAsync(int categoryID)
        {
            var category = await _dbContext.Categories
                .SingleOrDefaultAsync(c => c.CategoryID == categoryID);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 获取商品分类
        /// </summary>
        /// <param name="categoryID">分类ID</param>
        /// <returns>商品分类</returns>
        public async Task<Category> GetAsync(int categoryID)
        {
            return await _dbContext.Categories.SingleOrDefaultAsync(c => c.CategoryID == categoryID);
        }

        /// <summary>
        /// 获取商品分类总数
        /// </summary>
        /// <returns>商品分类总数</returns>
        public async Task<int> GetCount()
        {
            return await _dbContext.Categories.CountAsync();
        }

        /// <summary>
        /// 获取商品分类枚举
        /// </summary>
        /// <param name="categoryID">分类ID</param>
        /// <param name="filter">过滤</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns>商品分类</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync(int categoryID, string filter, int pageSize, int pageCount)
        {
            var results = await _dbContext.Products.Where
                (p => p.CategoryID == categoryID && (String.IsNullOrEmpty(filter) ||
                p.ProductName.Contains(filter) || p.Description.Contains(filter)))
                .Select(p => new { Product = p, })
                .Skip(pageSize * pageCount)
                .Take(pageSize)
                .ToListAsync();

            return results.Select(p => p.Product);
        }

        /// <summary>
        /// 更新商品分类
        /// </summary>
        /// <param name="category">商品分类</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Category category)
        {
            _dbContext.Categories.Update(category);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
