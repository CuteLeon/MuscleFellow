using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MuscleFellow.Models
{
    public class Product
    {
        [DisplayName("商品ID")]
        public Guid ProductID { get; set; }

        [DisplayName("生产商ID")]
        public int BrandID { get; set; }

        [DisplayName("分类ID")]
        public int CategoryID { get; set; }

        [DisplayName("商品名称")]
        public string ProductName { get; set; }

        [DisplayName("缩略图")]
        public string ThumbnailImage { get; set; }

        [DisplayName("图片列表")]
        public List<ProductImage> Images { get; set; }

        [DisplayName("长度")]
        public float Length { get; set; }

        [DisplayName("高度")]
        public float Height { get; set; }

        [DisplayName("宽度")]
        public float Width { get; set; }

        [DisplayName("长度单位")]
        public string UnitOfLength { get; set; }

        [DisplayName("重量")]
        public float Weight { get; set; }
    
        [DisplayName("重量单位")]
        public string UnitOfWeight { get; set; }

        [DisplayName("单价")]
        public float UnitPrice { get; set; }

        [DisplayName("货币")]
        public string Currency { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("最近更新时间")]
        public DateTime LastUpdateTime { get; set; }
    }
}
