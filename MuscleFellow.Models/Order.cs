using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleFellow.Models
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus : int
    {
        /// <summary>
        /// 等待支付
        /// </summary>
        PendingPayment,
        /// <summary>
        /// 等待装运
        /// </summary>
        PendingShipment,
        /// <summary>
        /// 等待计价
        /// </summary>
        PendingEvaluated,
        /// <summary>
        /// 已关闭
        /// </summary>
        Closed,
        /// <summary>
        /// 已取消
        /// </summary>
        Cancelled
    }
    public class Order
    {
        [Key]
        [DisplayName("订单ID")]
        public Guid OrderID { get; set; }

        [DisplayName("用户ID")]
        public string UserID { get; set; }

        [DisplayName("订单项目")]
        public List<OrderDetail> OrderItems { get; set; }

        [DisplayName("地址")]
        [MaxLength(128)]
        public string Address { get; set; }

        [DisplayName("总价")]
        public float TotalPrice { get; set; }

        [DisplayName("订单状态")]
        public OrderStatus OrderStatus { get; set; }

        [DisplayName("下单时间")]
        public DateTime? OrderDate { get; set; }
    }
}
