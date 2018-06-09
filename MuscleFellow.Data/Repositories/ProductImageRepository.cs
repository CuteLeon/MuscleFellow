using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuscleFellow.Data.Interfaces;
using MuscleFellow.Models;
using Microsoft.EntityFrameworkCore;

namespace MuscleFellow.Data.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private MuscleFellowDbContext _dbContext = null;
        public ProductImageRepository(MuscleFellowDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 添加商品图像
        /// </summary>
        /// <param name="productImage">商品图像</param>
        /// <returns></returns>
        public async Task<int> AddAsync(ProductImage productImage)
        {
            if (null == productImage)
                return -1;
            _dbContext.ProductImages.Add(productImage);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 删除商品图像
        /// </summary>
        /// <param name="productImageID">商品图像ID</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int productImageID)
        {
            var pi = _dbContext.ProductImages.SingleOrDefault(i => i.ImageID == productImageID);
            if (null != pi)
            {
                _dbContext.ProductImages.Remove(pi);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        /// <summary>
        /// 获取商品图像
        /// </summary>
        /// <param name="productImageID">商品图像ID</param>
        /// <returns>商品图像</returns>
        public async Task<ProductImage> GetAsync(int productImageID)
        {
            return await _dbContext.ProductImages
                .Where(i => i.ImageID == productImageID).SingleOrDefaultAsync();
        }

        /// <summary>
        /// 获取商品图像列表
        /// </summary>
        /// <param name="productID">商品图像ID</param>
        /// <returns>商品图像列表</returns>
        public async Task<List<ProductImage>> GetProductImages(Guid productID)
        {
            var results = await _dbContext.ProductImages.Where
                (i => i.ProductID == productID)
                .Select(i => new { ProductImage = i, })
                .ToListAsync();

            return results.Select(i => i.ProductImage).ToList();
        }

        /// <summary>
        /// 更新商品图像
        /// </summary>
        /// <param name="productImage">商品图像</param>
        /// <returns></returns>
        public async Task UpdateAsync(ProductImage productImage)
        {
            _dbContext.ProductImages.Update(productImage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
