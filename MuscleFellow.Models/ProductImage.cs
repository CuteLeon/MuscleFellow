using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleFellow.Models
{
    public class ProductImage
    {
        [DisplayName("图片ID"), Key]
        public int ImageID { get; set; }

        [DisplayName("商品ID")]
        public Guid ProductID { get; set; }

        [DisplayName("相关链接")]
        public string RelativeUrl { get; set; }

        [DisplayName("注释")]
        public string Comments { get; set; }
    }
}
