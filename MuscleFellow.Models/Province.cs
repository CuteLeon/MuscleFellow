using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleFellow.Models.BasicInfo
{
    public class Province
    {
        [DisplayName("省份ID")]
        public int ID { get; set; }

        [DisplayName("省份名称")]
        public string Name { get; set; }

        [DisplayName("城市列表")]
        public List<City> Cities { get; set; }
    }
}
