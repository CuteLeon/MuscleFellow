using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MuscleFellow.Models;

namespace MuscleFellow.Data.Interfaces
{
    public interface ICartItemRepository
    {
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="cartItem">购物车</param>
        /// <returns></returns>
        Task<int> AddAsync(CartItem cartItem);

        /// <summary>
        /// 增加购物车
        /// </summary>
        /// <param name="sessionID">会话ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="productID">商品ID</param>
        /// <param name="amount">总数</param>
        /// <returns></returns>
        Task<int> AddAsync(string sessionID, string userID, Guid productID, int amount);

        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="cartItemID">购物车ID</param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid cartItemID);

        /// <summary>
        /// 更新匿名购物车
        /// </summary>
        /// <param name="sessionID">会话ID</param>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        Task<int> UpdateAnonymousCartItem(string sessionID, string userID);

        /// <summary>
        /// 更新购物车
        /// </summary>
        /// <param name="cartItem">购物后侧</param>
        /// <returns></returns>
        Task<int> UpdateAsync(CartItem cartItem);

        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <param name="sessionID">会话ID</param>
        /// <param name="userID">用户ID</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns>购物车列表</returns>
        Task<List<CartItem>> GetCartItemsAsync(string sessionID, string userID, int pageSize, int pageCount);

        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <param name="sessionID">会话ID</param>
        /// <param name="pageSize">每页容量</param>
        /// <param name="pageCount">页数</param>
        /// <returns>购物车列表</returns>
        Task<List<CartItem>> GetCartItemsAsync(string sessionID, int pageSize, int pageCount);

        /// <summary>
        /// 获取购物车
        /// </summary>
        /// <param name="id">购物车ID</param>
        /// <returns>购物车</returns>
        Task<CartItem> GetByID(Guid id);
    }
}
