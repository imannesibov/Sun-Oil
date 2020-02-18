using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunOil.Model
{
    class Report
    {
        public PetrolType petrolType { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public double TotalPetrolPrice { get; set; }
        public string TotalCafePrice { get; set; }
        public string TotalGSPrice { get; set; }
        public Dictionary<Food, double> foodWithTotalPrice { get; set; }
        public DateTime BuyingDate { get; set; }
    }

}