using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.ORM.Good
{
    // 与商品类别表相对应的类
    [Serializable]
    public class Kind
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        // 类别的名字
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        // 该类别下的产品
        public IEnumerable<Product> Products { get; set; }
    }
}
