using System;
using System.ComponentModel.DataAnnotations;
namespace BestStore.Models
{
    // this is a product image description* *端口图片类型声明
    public class ProductImage
    {
        [Key]   //向Entity Framework 声明 ImageID 为此实体唯一主键
        public int ImageID { get; set; }
        public Guid ProductID { get; set; }
        public string RelativeUrl { get; set; }
        public string Comments { get; set; }

    }

}