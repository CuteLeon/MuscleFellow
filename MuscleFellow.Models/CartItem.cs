using System;
using System.ComponentModel;

namespace MuscleFellow.Models
{
    public class CartItem
    {
        [DisplayName("购物车ID")]
        public Guid CartID { get; set; }

        [DisplayName("用户ID")]
        public string UserID { get; set; }

        [DisplayName("会话ID")]
        public string SessionID { get; set; }

        [DisplayName("商品ID")]
        public Guid ProductID { get; set; }

        [DisplayName("商品名称")]
        public string ProductName { get; set; }

        [DisplayName("缩略图路径")]
        public string ThumbImagePath { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("单价")]
        public float UnitPrice { get; set; }

        [DisplayName("小计")]
        public float SubTotal { get; set; }

        [DisplayName("最近更新时间")]
        public DateTime LastUpdatedDateTime { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreatedDateTime { get; set; }
    }
}
