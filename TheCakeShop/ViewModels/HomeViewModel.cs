using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCakeShop.Models;

namespace TheCakeShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}
