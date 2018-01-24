﻿using System;
using System.Collections.Generic;
namespace BestStore.Models
{
    // 商品品牌实体模型声明
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }

    }

}