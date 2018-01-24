using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestStore.Models
{
    // 创建订单实体模型
    // 首先声明个订单状态，枚举类型

    public enum OrderStatus : int
    {
        PendingPayment,
        PengdingShipment,
        PengdingEvaluated,
        Closed,
        Cancelled
    }
    //实体类声明
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public string UserID { get; set; }
        public List<OrderDetail> OrderItems { get; set; }
        [MaxLength(128)]
        public string Address { get; set; }
        public float TotalPrice { get; set; }
        public OrderStatus OrderState { get; set; }
        public DateTime? OrderDate { get; set; }

    }

}