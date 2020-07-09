using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.DTO.User
{
    [Serializable]
    public class CustomerLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
