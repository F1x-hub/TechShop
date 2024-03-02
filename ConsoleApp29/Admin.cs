using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Admin : Person
    {

        public override string ToString()
        {
            return $"Name: {Name} - LastName: {LastName} - UserName: {UserName} - Password: {Password}";
        }
    }
}
