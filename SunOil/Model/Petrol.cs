using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunOil.Model
{
    enum PetrolType
    {
        Diesel,
        LPG,
        BioDiesel 

    }
    class Petrol
    {
        public PetrolType Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
