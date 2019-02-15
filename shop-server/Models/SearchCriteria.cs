using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class SearchCriteria
    {
        public int From { get; set; }
        public int To { get; set; }
        public string Rating { get; set; }
        public string Search { get; set; }
        public string Type { get; set; }
    }
}
