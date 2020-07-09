using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Models.ORM.Shop
{
    // 与订单相对应的类
    [Serializable]
    public class Order
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 订单号
        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();
        
        // 下单时间
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        // 收货地址
        public Location Location { get; set; }

        // 下单人
        public Customer Customer { get; set; }

        // 订单条目
        public IEnumerable<Item> Items { get; set; }

    }
}
