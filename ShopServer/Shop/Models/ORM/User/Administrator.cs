using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.ORM.User
{
    // 与后台管理员表对应的类
    [Serializable]
    public class Administrator
    {
        // 表的主键
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // 管理员的用户名
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        
        // 管理员的密码
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // 创建时间
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

    }
}
