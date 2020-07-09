using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Models.ORM.Utils
{
    // 由于EF Core暂时不支持自动维护多对多关系
    // 所以使用一个额外的类来维护一对多, 多对一的关系
    // 与维护顾客和收货地址关系表的类
    [Serializable]
    public class CustomerLocation
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 顾客
        public Customer Customer { get; set; }

        // 收货地址
        public Location Location { get; set; }

    }
}
