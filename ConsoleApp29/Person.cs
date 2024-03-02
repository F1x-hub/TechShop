using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }
        public List<Product> ProductList { get; set; }
        public Person()
        {
            ProductList = new List<Product>();

            
        }
        public override string ToString()
        {
            List<object> productobject = new List<object>();
            foreach (var product in ProductList)
            {
                productobject.Add(product);
            }


            string productListString = string.Join(", ", productobject);

            return $"Name: {Name} - LastName: {LastName} - UserName: {UserName} - Password: {Password} - Balance: {Balance} - Products: {productListString}";
        }
    }
}
