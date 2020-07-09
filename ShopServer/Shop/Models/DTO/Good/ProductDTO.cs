using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.DTO.Good
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Repository { get; set; }
        public string Message { get; set; }
        public string Kind { get; set; }
        public string Supplier { get; set; }

    }
}
