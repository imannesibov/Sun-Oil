using SunOil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunOil
{ 

    class GasStation
    {
        public MiniCafe miniCafe = new MiniCafe();
        public List<Petrol> Petrol { get; set; } = new List<Petrol>();
    

        public GasStation()
        {
            Petrol.Add(new Model.Petrol { Name = PetrolType.BioDiesel, Price = 0.70 });
            Petrol.Add(new Model.Petrol { Name = PetrolType.Diesel, Price = 2.10 });
            Petrol.Add(new Model.Petrol { Name = PetrolType.LPG, Price = 3.90 });
        }

    }
}
