using System;
using System.ComponentModel.DataAnnotations;

namespace BestStore.Models
{
    // 创建用户地址模型
    public class ShipAddress
    {
        public int AddressID { get; set; }
        public string UserID { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 4)]
        public string Address { get; set; }
        public string ZipCode { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Receiver { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        //重载，返回完整的送货地址字符串
        public override string ToString()
        {
            return this.Address;
        }
    }
}