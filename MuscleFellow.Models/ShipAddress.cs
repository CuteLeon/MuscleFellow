using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleFellow.Models
{
    public class ShipAddress
    {
        /// <summary>
        /// 分字符
        /// </summary>
        private readonly string Sepertator = ", ";

        [DisplayName("地址ID")]
        public int AddressID { get; set; }

        [DisplayName("用户ID")]
        public string UserID { get; set; }

        [DisplayName("省份")]
        public string Province { get; set; }

        [DisplayName("城市")]
        public string City { get; set; }

        [DisplayName("地址")]
        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Address { get; set; }

        [DisplayName("邮政编码")]
        public string ZipCode { get; set; }

        [DisplayName("收货人")]
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Receiver { get; set; }

        [DisplayName("联系方式")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return CompositeAddress();
        }

        /// <summary>
        /// 组装地址
        /// </summary>
        /// <returns>地址</returns>
        private string CompositeAddress()
        {
            StringBuilder sb = new StringBuilder(200);
            if (!string.IsNullOrEmpty(Province))
            {
                sb.Append(Province);
                if (!string.IsNullOrEmpty(City))
                    sb.Append(Sepertator + City);
            }
            if (!string.IsNullOrEmpty(Address))
                sb.Append(Sepertator + Address);
            if (!string.IsNullOrEmpty(Receiver))
                sb.Append(Sepertator + Receiver + "收");
            if (!string.IsNullOrEmpty(ZipCode))
                sb.Append(Sepertator + "邮编:" + ZipCode);
            if (!string.IsNullOrEmpty(PhoneNumber))
                sb.Append(Sepertator + "电话:" + PhoneNumber);
            return sb.ToString();
        }
    }
}
