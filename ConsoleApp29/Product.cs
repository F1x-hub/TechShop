using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Product
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Added { get; set; }
        public int Price { get; set; }
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer} - Name: {Name} - Description: {Description} - Quantity: {Quantity} - Price: {Price} - Added: {Added}";
        }
    }
}
