using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Good;
using Shop.Models.ORM.User;

namespace Shop.Models.ORM.Shop
{
    // 与订单条目表相关的类
    [Serializable]
    public class Item
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 订单
        public Order Order { get; set; }

        // 商品数量
        [Required]
        public int Count { get; set; }

        // 商品
        public Product Product { get; set; }

    }
}
