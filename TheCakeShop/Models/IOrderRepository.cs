using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeShop.Models
{
    public interface IOrderRepository
    {
        void Createorder(Order order);
    }
}
