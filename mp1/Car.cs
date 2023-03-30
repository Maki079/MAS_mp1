using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp1
{
    internal class Car
    {
        private static List<Car> carsExtent = new();

        Car() 
        {
            carsExtent.Add(this);
        }
        public string VIN { get; set; }
        public string ManufacturedDate { get; set; }
        public string Mileage { get; set; }
        public string Power { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
}
