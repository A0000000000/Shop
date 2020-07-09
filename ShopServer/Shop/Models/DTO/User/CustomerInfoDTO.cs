using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.DTO.User
{
    public class CustomerInfoDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreateTime { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
