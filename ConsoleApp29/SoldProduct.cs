using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class SoldProduct<T>
    {
        public Person WhoBuys { get; set; }
        public Product WhatBuys { get; set; }
        public DateTime BuyngTime { get; set; }

        public override string ToString()
        {
            return $"WhoBuys: {WhoBuys.Name} - WhatBuys: {WhatBuys.Name} - BuyngTime: {BuyngTime}";
        }
    }
}
