using System;
using System.Collections.Generic;
namespace BestStore.Models
{
    // 商品类型实体模型声明
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }

    }

}