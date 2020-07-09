using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Models.ORM.Utils;

namespace Shop.Models.ORM.Good
{
    // 与供应商表相对应的类
    [Serializable]
    public class Supplier
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 供应商的名字
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // 所供应的商品
        public IEnumerable<ProductSupplier> ProductSuppliers { get; set; }

    }
}
