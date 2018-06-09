using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleFellow.Models
{
    public class OrderDetail
    {
        [DisplayName("订单明细ID")]
        public int OrderDetailID { get; set; }

        [DisplayName("订单ID")]
        public Guid OrderID { get; set; }

        [DisplayName("商品ID")]
        public Guid ProductID { get; set; }

        [DisplayName("产品名称")]
        public string ProductName { get; set; }

        [DisplayName("缩略图路径")]
        public string ThumbImagePath { get; set; }

        [DisplayName("数量")]
        public int Quantity { get; set; }

        [DisplayName("单价")]
        public float UnitPrice { get; set; }

        [DisplayName("小计")]
        public float SubTotal { get; set; }

        [DisplayName("下单时间")]
        public DateTime? PlaceDate { get; set; }
    }
}
