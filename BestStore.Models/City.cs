using System;
using System.ComponentModel.DataAnnotations;
namespace BestStore.Models {
    // 城市模型声明
    public class City {
        [Key]
        public int CityID { get; set; }
        public int CityIndex { get; set; }
        public int ProvinceID { get; set; }
        public string CityName { get; set; }
    }

}