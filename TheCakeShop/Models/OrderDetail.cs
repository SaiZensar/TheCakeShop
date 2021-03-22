using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; } //Quantity Ordered
        public decimal Price { get; set; }
        public Pie Pie { get; set; }
        public Order Order { get; set; }
    }
}
