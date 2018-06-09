using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MuscleFellow.Models.BasicInfo
{
    public class City
    {
        [Key]
        [DisplayName("城市ID")]
        public int ID { get; set; }

        [DisplayName("城市标识")]
        public int CityIndex { get; set; }

        [DisplayName("省份ID")]
        public int ProvinceID { get; set; }

        [DisplayName("城市名称")]
        public string Name { get; set; }
    }
}
