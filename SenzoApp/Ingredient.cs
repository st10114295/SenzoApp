using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenzoApp
{
    internal class Ingredient
    {
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Foodgroup { get; set; }
        public double Quantity { get; set; }
        public int Calories { get; set; }
    }
}
