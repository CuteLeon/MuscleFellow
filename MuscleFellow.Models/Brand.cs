using System.Collections.Generic;
using System.ComponentModel;

namespace MuscleFellow.Models
{
    public class Brand
    {
        [DisplayName("生产商ID")]
        public int BrandID { get; set; }

        [DisplayName("生产商名称")]
        public string BrandName { get; set; }

        [DisplayName("Logo")]
        public string Logo { get; set; }

        [DisplayName("描述")]
        public string Description { get; set; }

        [DisplayName("商品列表")]
        public List<Product> Products { get; set; }
    }
}
