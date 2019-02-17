using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class OrderViewModel
    {
        public string ID { get; set; }
        public string Customer { get; set; }
        public int[] ProductsIds { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
    }
}
