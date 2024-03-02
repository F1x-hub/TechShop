using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class ProductBuyng
    {
        List<Product> products = new List<Product>()
        {
                new Product(){Manufacturer = "Razer", Name = "Viper Ultimate", Description = "the best mouse", Quantity = 223, Price = 449, ProductId = 1},
                new Product(){Manufacturer = "Logitech", Name = "Pro X", Description = "fastest PRO mouse ever.", Quantity = 123, Price = 129, ProductId = 1}
        };
        List<SoldProduct<Product>> soldProducts = new List<SoldProduct<Product>>();
        List<Category> categories = new List<Category>()
        {
                new Category(){Id = 1, Name = "Mouse"}
        };

        List<Person> persons = new List<Person>()
        {
            new User(){Name = "morty", LastName = "Smith", UserName = "F1x", Password = "1234", Balance = 2000},
            new User(){Name = "Summer", LastName = "Smith", UserName = "llol", Password = "4321", Balance = 1000},
            new Admin(){Name = "John", LastName = "Johnson", UserName = "ninja", Password = "1111"}
        };

        public void TechShopMenu()
        {
            int choiseMenu = 0;
            while (choiseMenu != 3)
            {
                try
                {
                    Console.WriteLine("TechShop");
                    Console.WriteLine("1. Registration\n2. LogIn\n3. Exit");
                    choiseMenu = int.Parse(Console.ReadLine());

                    if (choiseMenu == 1)
                    {
                        Registration();
                    }
                    if (choiseMenu == 2)
                    {
                        LogIn();
                    }
                }
                catch (FormatException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }
        public void Registration()
        {
            string type = TypeChoice();
            string name = "";
            string lastName = "";
            string userName = "";
            string password = "";
            if (type == "User" || type == "Admin")
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                Console.Write("Enter LastName: ");
                lastName = Console.ReadLine();
                Console.Write("Enter UserName: ");
                userName = Console.ReadLine();
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
            }



            if (type == "User")
            {
                try
                {
                    Console.Write("Enter Balance: ");
                    int balance = int.Parse(Console.ReadLine());
                    
                    persons.Add(new User() { Name = name, LastName = lastName, UserName = userName, Password = password, Balance = balance});
                }
                catch (FormatException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
            if (type == "Admin")
            {
                
                persons.Add(new Admin() { Name = name, LastName = lastName, UserName = userName, Password = password, });
            }
            

        }
       
        public void LogIn()
        {
            string type = TypeChoice();
            string userName = "";
            string Password = "";
            Person newPerson = null;
            if (type == "User" || type == "Admin")
            {
                Console.Write("Enter UserName: ");
                userName = Console.ReadLine();
                Console.Write("Enter Password: ");
                Password = Console.ReadLine();
            }
            bool found = false;

            if (type == "User")
            {
                
                foreach (var person in persons)
                {
                    if (person is User users && users.UserName.ToLower() == userName.ToLower() && users.Password.ToLower() == Password.ToLower())
                    {
                        newPerson = users;
                        Console.WriteLine($"Success: {newPerson.Name}");
                        found = true;
                        ShopMenu(newPerson);
                    }
                    
                }
                if (found == false) 
                {
                    Console.WriteLine("User Not Found");
                }
            }
            if (type == "Admin")
            {
                foreach (var person in persons)
                {
                    if (person is Admin employee && employee.UserName.ToLower() == userName.ToLower() && employee.Password.ToLower() == Password.ToLower())
                    {
                        newPerson = employee;
                        Console.WriteLine($"Success: {newPerson.Name}");
                        found = true;
                        AdminMenu(newPerson);
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("User Not Found");
                }
            }
        }
        public void AdminMenu(Person admin)
        {
            int choiseMenu = 0;
            while (choiseMenu != 3)
            {
                try
                {
                    Console.WriteLine("1. CRUDMenu\n2. soldProduct\n3. Exit");
                    choiseMenu = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (choiseMenu == 1)
                {
                    CRUD();
                }
                if (choiseMenu == 2)
                {
                    soldProduct();
                }
            }
        }
        public void soldProduct()
        {
            int choiseMenu = 0;
            try
            {
                soldProducts.ForEach(p => Console.WriteLine(p));
                Console.WriteLine("1. see items sold this week\n2. see items sold this month\n3. see items sold this year");
                choiseMenu = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (choiseMenu == 1)
            {
                
                DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                DateTime endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                
                var soldThisWeek = soldProducts.Where(p => p.BuyngTime >= startOfWeek && p.BuyngTime <= endOfWeek);

                
                Console.WriteLine("Sold products this week:");
                soldThisWeek.ToList().ForEach(p => Console.WriteLine(p));
            }
            else if (choiseMenu == 2)
            {
                
                DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddSeconds(-1);

                
                var soldThisMonth = soldProducts.Where(p => p.BuyngTime >= startOfMonth && p.BuyngTime <= endOfMonth);

                
                Console.WriteLine("Sold products this month:");
                soldThisMonth.ToList().ForEach(p => Console.WriteLine(p));
            }
            else if (choiseMenu == 3)
            {
               
                DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime endOfYear = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);

                
                var soldThisYear = soldProducts.Where(p => p.BuyngTime >= startOfYear && p.BuyngTime <= endOfYear);

                
                Console.WriteLine("Sold products this year:");
                soldThisYear.ToList().ForEach(p => Console.WriteLine(p));
            }
        }
        public int ChoiseCategory()
        {
            Console.WriteLine("1. Mouse\n2. Keyboard");

            int choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                Console.WriteLine("Success");
                return 1;
            }
            if (choise == 2)
            {
                Console.WriteLine("Success");
                return 2;
            }
            return 0;
        }
        public void CRUD()
        {
            int choiseMenu = 0;
            while (choiseMenu != 5)
            {
                try
                {
                    Console.WriteLine("1. Add Product\n2. See Product\n3. Edit Product\n4. Delete Product\n5. Exit");
                    choiseMenu = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (choiseMenu == 1)
                {
                    Console.Write("Enter Manufacturer: ");
                    string manufacturer = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.Write("Choise Category:");
                    int category = ChoiseCategory();
                    products.Add(new Product()
                    {
                        Manufacturer = manufacturer,
                        Name = name,
                        Description = description,
                        Quantity = quantity,
                        Price = price,
                        ProductId = category,
                    });
                }
                if (choiseMenu == 2)
                {
                    products.ForEach(p => Console.WriteLine(p));
                }
                if (choiseMenu == 3)
                {
                    Console.Write("Enter the name of the product you want to edit: ");
                    string searchName = Console.ReadLine();
                    var foundProduct = products.FirstOrDefault(p => p.Name.ToLower() == searchName.ToLower());
                    if (foundProduct != null)
                    {
                        
                        Console.Write("Manufacturer: ");
                        string manufacturer = Console.ReadLine();
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Description: ");
                        string description = Console.ReadLine();
                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Price: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Choise Category:");
                        int category = ChoiseCategory();

                        
                        foundProduct.Manufacturer = manufacturer;
                        foundProduct.Name = name;
                        foundProduct.Description = description;
                        foundProduct.Quantity = quantity;
                        foundProduct.Price = price;
                        foundProduct.ProductId = category;

                        Console.WriteLine("Product updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("No product found with the given name");
                    }
                }
                if (choiseMenu == 4)
                {
                    Console.Write("Enter the name of the product you want to delete: ");
                    string searchName = Console.ReadLine();
                    var foundProduct = products.FirstOrDefault(p => p.Name.ToLower() == searchName.ToLower());
                    if (foundProduct != null)
                    {
                        products.Remove(foundProduct);
                        Console.WriteLine("Product deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("No product found with the given name.");
                    }
                }
            }
        }
        public void ShopMenu(Person user)
        {
            int choiseMenu = 0;
            while (choiseMenu != 4)
            {
                try
                {
                    Console.WriteLine("1. Shop\n2. ProductCard\n3. Profile\n4. Exit");
                    choiseMenu = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                if (choiseMenu == 1)
                {
                    Category(user);
                }
                if (choiseMenu == 2)
                {
                    ProductCard(user);
                }
                if (choiseMenu == 3) 
                {
                    ProfileEdit(user);
                }
            }
        }
        public void ProfileEdit(Person user)
        {
            if (user != null)
            {

                int choiseMenu = 0;
                while (choiseMenu != 3)
                {
                    try
                    {
                        
                        Console.WriteLine("1. Change Profile\n2. Delete Acc\n3. Exit");
                        choiseMenu = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if(choiseMenu == 1)
                    {
                        Action<Person> edit = delegate (Person user1)
                        {
                            Console.WriteLine(user1);
                            Console.Write("Enter new UserName: ");
                            string userName = Console.ReadLine();
                            Console.Write("Enter new Password: ");
                            string password = Console.ReadLine();

                            user1.UserName = userName;
                            user1.Password = password;
                            Console.WriteLine(user1);
                        };
                        edit(user);

                    }
                    if (choiseMenu == 2)
                    {
                        Console.WriteLine(user);
                        
                        foreach(var person in persons)
                        {
                            if(person.Name == user.Name && person.LastName == user.LastName)
                            {
                                
                                persons.Remove(person);
                                break;
                            }
                        }
                        user = null;
                        Console.WriteLine("Account deleted");
                        TechShopMenu();
                    }
                }

            }
        }
        public void Category(Person user)
        {
            if (user != null)
            {
                int choiseMenu = 0;
                while (choiseMenu != 3)
                {
                    try
                    {
                        Console.WriteLine("Choose Category: ");
                        Console.WriteLine("1. Mouse\n2. Keyboard\n3. Exit");
                        choiseMenu = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (choiseMenu == 1)
                    {
                        Shop(user, choiseMenu);
                    }
                    if (choiseMenu == 2)
                    {
                        Shop(user, choiseMenu);
                    }
                    if (choiseMenu == 3)
                    {

                    }
                }
            }
        }
        public void ProductCard(Person user)
        {
            if (user != null)
            {
                int choiseMenu = 0;
                while (choiseMenu != 4)
                {
                    try
                    {
                        Console.WriteLine("1. Edit\n2. Delete\n3. Buy\n4. Exit");
                        choiseMenu = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    if (choiseMenu == 1)
                    {
                        Edit(user);
                    } 
                    if (choiseMenu == 2)
                    {
                        Delete(user);
                    }
                    if (choiseMenu == 3)
                    {
                        Buy(user);
                    }
                }
            }
        }
        public void Delete(Person user) 
        {
            if (user != null)
            {
                Console.WriteLine(user);
                Console.Write("Search By Name: ");
                string name = Console.ReadLine();

                foreach (var person in user.ProductList)
                {
                    if (person.Name == name)
                    {
                        user.ProductList.Remove(person);
                        Console.WriteLine($"Product '{name}' removed successfully.");
                        break;

                    }
                }
            }
        }
        public void Buy(Person user)
        {
            if (user  != null)
            {
                int choise = 0;
                while (choise != 3)
                {
                    Console.WriteLine(user);
                    Console.WriteLine("\n1. Buy One\n2. Buy All\n3. Exit");
                    choise = int.Parse(Console.ReadLine());

                    if (choise == 1)
                    {

                        Action<Person> buyOne = delegate (Person user1)
                        {
                            Console.Write("Search By Name: ");
                            string name = Console.ReadLine();

                            for (int i = user1.ProductList.Count - 1; i >= 0; i--)
                            {
                                var product = user1.ProductList[i];
                                if (product.Name == name && user1.Balance >= (product.Price * product.Added))
                                {
                                    user1.Balance -= product.Price;

                                    soldProducts.Add(new SoldProduct<Product>
                                    {
                                        WhoBuys = user1,
                                        WhatBuys = product,
                                        BuyngTime = DateTime.Now
                                    });
                                    foreach (var soldProduct in soldProducts)
                                    {
                                        Console.WriteLine($"Product '{product.Name}' was sold to {user1.Name} at {soldProduct.BuyngTime}");
                                    }

                                    user1.ProductList.RemoveAt(i);
                                }
                                else if (user1.Balance < product.Price)
                                {
                                    Console.WriteLine("Don't Enough Money");
                                }
                            }
                        };

                        buyOne(user);
                        
                    }
                    if (choise == 2)
                    {
                        Action<Person> buyAll = delegate (Person user1)
                        {
                            
                            List<Product> productListCopy = new List<Product>();
                            foreach (var product in user1.ProductList)
                            {
                                productListCopy.Add(product);
                            }

                            foreach (var product in productListCopy)
                            {
                                if (user1.Balance >= product.Price)
                                {
                                    user1.Balance -= product.Price;

                                    soldProducts.Add(new SoldProduct<Product>
                                    {
                                        WhoBuys = user1,
                                        WhatBuys = product,
                                        BuyngTime = DateTime.Now
                                    });
                                    foreach(var soldProduct in soldProducts)
                                    {
                                        Console.WriteLine($"Product '{product.Name}' was sold to {user1.Name} at {soldProduct.BuyngTime}");
                                    }
                                    
                                    user1.ProductList.Remove(product);
                                }
                                else
                                {
                                    Console.WriteLine($"Not enough balance to buy {product.Name}");
                                }
                            }
                        };

                        
                        buyAll(user);
                        
                    }
                }
            }
        }
        public void Edit(Person user) 
        {
            if (user != null)
            {

                int choise = 0;
                while(choise != 3)
                {
                    Console.WriteLine(user);
                    Console.WriteLine("\n1. increase\n2. decrease\n3. Exit");
                    choise = int.Parse(Console.ReadLine());
                    Console.Write("Search By Name: ");
                    string name = Console.ReadLine();

                    if (choise == 1)
                    {
                        foreach (var person in user.ProductList)
                        {
                            if (person.Name == name)
                            {
                                Console.Write("Enter Quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                person.Added += quantity;
                                
                            }
                        }
                    }
                    if (choise == 2)
                    {
                        foreach (var person in user.ProductList)
                        {
                            if (person.Name == name)
                            {
                                Console.Write("Enter Quantity: ");
                                person.Added -= int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    Console.WriteLine(user);
                }
               
            }
                
        }
        public void Shop(Person user, int id)
        {
            if(user != null) 
            {
                bool choise = false;
                foreach (var category  in categories) 
                {
                    foreach (var product in products)
                    {
                        if (product.ProductId == id && category.Id == id)
                        {
                            Console.WriteLine($"{category} - {product}");
                            choise = true;
                        }
                    }
                }
                if (choise == true) 
                {
                    Console.Write("Buy Product by Name: ");
                    string name = Console.ReadLine();
                    foreach (var category in categories)
                    {
                        foreach (var product in products)
                        {
                            if (product.ProductId == id && category.Id == id)
                            {
                                if (product.Name == name && product.Price < user.Balance)
                                {
                                    product.Quantity -= 1;
                                    product.Added += 1;
                                    
                                    user.ProductList.Add(product);
                                }
                                
                            }
                        }
                    }
                }
                Console.WriteLine(user);
            }
        }
        public string TypeChoice()
        {
            try
            {
                int menuChoice = 0;
                while (menuChoice != 3)
                {
                    Console.WriteLine("Choose type:\n1. User\n2. Admin");
                    menuChoice = int.Parse(Console.ReadLine());

                    if (menuChoice == 1)
                    {
                        return "User";
                    }
                    if (menuChoice == 2)
                    {
                        return "Admin";
                    }
                }
                return "User";
            }
            catch (FormatException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                return "Error";
            }

        }
        public void Print()
        {
            
            foreach(var category in soldProducts) 
            {
                Console.WriteLine(category);
            }
        }


    }
}
