using System;
namespace BestStore.Models
{
    // 订单明细模型声明
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ThumbImagePath { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float SubTotal{ get; set; }
        public DateTime? PlaceDate { get; set; }
    }

}