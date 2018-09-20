using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class OrderLine
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
