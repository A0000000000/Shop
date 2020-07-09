using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shop.Models.ORM.Utils;

namespace Shop.Models.ORM.Good
{
    // 与商品表相对应的类
    [Serializable]
    public class Product
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 商品的名字
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        // 商品的价格
        [Required]
        public decimal Price { get; set; }
        
        // 商品的库存
        [Required]
        public uint Repository { get; set; }
        
        // 商品的简介
        [StringLength(1024)]
        public string Message { get; set; }

        // 商品的种类
        public Kind Kind { get; set; }

        // 商品的供应商
        public IEnumerable<ProductSupplier> ProductSuppliers { get; set; }

    }
}
