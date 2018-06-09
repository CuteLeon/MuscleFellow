using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MuscleFellow.Models;
using MuscleFellow.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using MuscleFellow.Models.BasicInfo;

namespace MuscleFellow.Data.Repositories
{
    public class ShipAddressRepository : IShipAddressRepository
    {
        private readonly MuscleFellowDbContext _dbContext;
        public ShipAddressRepository(MuscleFellowDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// 添加地址
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public async Task<int> AddAsync(ShipAddress address)
        {
            _dbContext.ShipAddress.Add(address);
            await _dbContext.SaveChangesAsync();
            return address.AddressID;
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="addressID">地址ID</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int addressID)
        {
            var address = _dbContext.ShipAddress.SingleOrDefault(a => a.AddressID == addressID);
            if (null != address)
            {
                _dbContext.Remove(address);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        /// <summary>
        /// 获取地址列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns>地址列表</returns>
        public async Task<List<ShipAddress>> GetAddressAsync(string userID, int pageSize, int pageCount)
        {
            var results = await _dbContext.ShipAddress.Where(a => a.UserID == userID)
                    .Select(a => new { ShipAddress = a, })
                    .Skip(pageSize * pageCount)
                    .Take(pageSize)
                    .ToListAsync();
            return results.Select(a => a.ShipAddress).ToList();
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="id">地址ID</param>
        /// <returns>地址</returns>
        public async Task<ShipAddress> GetAsync(int id)
        {
            if (0 >= id)
                return null;
            return await _dbContext.ShipAddress.FirstOrDefaultAsync(a => a.AddressID == id);
        }

        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(ShipAddress address)
        {
            if (null == address)
                return -1;
            _dbContext.ShipAddress.Update(address);
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 获取地址列表
        /// </summary>
        /// <returns>地址列表</returns>
        public async Task<List<Province>> GetProvincesAsync()
        {
            return  await _dbContext.Provinces.ToListAsync();
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <param name="provinceID">省份ID</param>
        /// <returns>城市列表</returns>
        public async Task<List<City>> GetCitiesAsync(int provinceID)
        {
            return await _dbContext.Cities.Where(a => a.ProvinceID == provinceID).ToListAsync();
        }

        /// <summary>
        /// 获取省份名称
        /// </summary>
        /// <param name="provinceID">省份ID</param>
        /// <returns>省份名称</returns>
        public async Task<string> GetProvinceNameAsync(int provinceID)
        {
            Province province = await _dbContext.Provinces.SingleOrDefaultAsync(p => p.ID == provinceID);
            if (null == province)
                return string.Empty;
            else
                return province.Name;
        }

        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="cityID">城市ID</param>
        /// <returns>城市名称</returns>
        public async Task<string> GetCityNameAsync(int cityID)
        {
            City city = await _dbContext.Cities.SingleOrDefaultAsync(c => c.ID == cityID);
            if (null == city)
                return string.Empty;
            else
                return city.Name;
        }
    }
}
