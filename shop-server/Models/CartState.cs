using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class CartState
    {
        public Product[] Products { get; set; }
        public int Total { get; set; }
        public bool Delivery { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
    }
}
