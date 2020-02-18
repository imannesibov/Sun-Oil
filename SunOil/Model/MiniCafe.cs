using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunOil
{
    
    class MiniCafe
    {
        public List<Food> Food { get; set; } = new List<Food>();

        public MiniCafe()
        {
            Food.Add(new Food { Name = "HotDog",Price = 1 ,Count = 1});
            Food.Add(new Food { Name = "Hamburger", Price = 2, Count = 1 });
            Food.Add(new Food { Name = "PotatoFri", Price = 3, Count = 1 });
            Food.Add(new Food { Name = "Cola", Price = 100, Count = 1 });
            }



    }
}
