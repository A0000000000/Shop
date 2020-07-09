using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Models.ORM.Shop;
using Shop.Models.ORM.Utils;

namespace Shop.Models.ORM.User
{
    // 与顾客表相对应的类
    [Serializable]
    public class Customer
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 用户名
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        // 密码
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        // 生日
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        // 创建时间
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        // 电子邮件
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        // 手机号码
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        // 收货地址
        public IEnumerable<CustomerLocation> CustomerLocations { get; set; }

        // 所下的订单
        public IEnumerable<Order> Orders { get; set; }

    }
}
