using Microsoft.EntityFrameworkCore;
using MuscleFellow.Data.Interfaces;
using MuscleFellow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleFellow.Data.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private MuscleFellowDbContext _dbContext = null;
        public OrderDetailRepository(MuscleFellowDbContext context)
        {
            _dbContext = context;
        }
        
        /// <summary>
        /// 添加订单明细
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Add(orderDetail);
            await _dbContext.SaveChangesAsync();
            return orderDetail.OrderDetailID;
        }

        /// <summary>
        /// 删除订单明细
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int orderDetailID)
        {
            var orderDetail = await _dbContext.OrderDetails.SingleOrDefaultAsync(o => o.OrderDetailID == orderDetailID);
            if (null != orderDetail)
            {
                _dbContext.OrderDetails.Remove(orderDetail);
                await _dbContext.SaveChangesAsync();
                return orderDetailID;
            }
            return -1;
        }

        /// <summary>
        /// 获取订单明细枚举
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync(Guid orderID, int pageSize, int pageCount)
        {
            var results = await _dbContext.OrderDetails.Where(o => o.OrderID == orderID)
                               .Select(o => new { Order = o, })
                               .OrderByDescending(o => o.Order.PlaceDate)
                               .Skip(pageSize * pageCount)
                               .Take(pageSize)
                               .ToListAsync();
            return results.Select(o => o.Order);
        }

        /// <summary>
        /// 更新订单明细
        /// </summary>
        /// <param name="orderDetail">订单明细</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
