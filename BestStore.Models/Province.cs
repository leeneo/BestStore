using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Collections.Generic;
namespace BestStore.Models {
    // 省份模型声明
    public class Province {
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public List<City> Cities { get; set; }

    }

}