using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Utils;

namespace Shop.Models.ORM.User
{
    // 与收货地址表相关的类
    [Serializable]
    public class Location
    {
        // 主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 邮政编码
        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        // 位置名字
        [Required]
        public string Name { get; set; }

        // 该地址的顾客
        public IEnumerable<CustomerLocation> CustomerLocations { get; set; }

    }
}
