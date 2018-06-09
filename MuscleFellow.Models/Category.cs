using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MuscleFellow.Models
{
    public class Category
    {
        [DisplayName("分类ID")]
        public int CategoryID { get; set; }

        [DisplayName("分类名称")]
        public string CategoryName { get; set; }

        [DisplayName("商品")]
        public List<Product> Products { get; set; }
    }
}
