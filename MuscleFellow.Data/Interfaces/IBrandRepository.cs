using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuscleFellow.Models;

namespace MuscleFellow.Data.Interfaces
{
    public interface IBrandRepository
    {
        /// <summary>
        /// 添加生产商
        /// </summary>
        /// <param name="brand">生产商</param>
        /// <returns></returns>
        Task<int> AddAsync(Brand brand);

        /// <summary>
        /// 删除生产商
        /// </summary>
        /// <param name="brandID">生产商ID</param>
        /// <returns></returns>
        Task DeleteAsync(int brandID);

        /// <summary>
        /// 获取生产商
        /// </summary>
        /// <param name="brandID">生产商ID</param>
        /// <returns>生产商</returns>
        Task<Brand> GetAsync(int brandID);

        /// <summary>
        /// 获取所有生产商
        /// </summary>
        /// <returns>生产商列表</returns>
        Task<List<Brand>> GetAllAsync();

        /// <summary>
        /// 获取生产商总数
        /// </summary>
        /// <returns>生产商总数</returns>
        Task<int> GetCountAsync();

        /// <summary>
        /// 获取商品枚举
        /// </summary>
        /// <param name="brandId">生产商ID</param>
        /// <param name="filter">过滤</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsAsync(int brandId, string filter, int pageSize, int pageCount);

        /// <summary>
        /// 更新生产商信息
        /// </summary>
        /// <param name="brand">生产商</param>
        /// <returns></returns>
        Task UpdateAsync(Brand brand);
    }
}
