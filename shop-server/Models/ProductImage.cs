using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class ProductImage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string Type { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
