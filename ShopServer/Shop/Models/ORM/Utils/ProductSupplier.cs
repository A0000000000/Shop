using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Good;

namespace Shop.Models.ORM.Utils
{
    // 由于EF Core暂时不支持自动维护多对多关系
    // 所以使用一个额外的类来维护一对多, 多对一的关系
    // 维护商品与供应商多对多关系表所对应的类
    [Serializable]
    public class ProductSupplier
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 所对应的商品
        public Product Product { get; set; }

        // 所对应的供应商
        public Supplier Supplier { get; set; }

    }
}
