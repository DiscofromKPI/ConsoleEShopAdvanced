using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class AddProductCommand : CommandBase
    {
        public override string Name => "add product";
        public override string Description => "Adds new product";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is AdminController adminController))
                return controller;
            
            var products = GoodRepo.Products;

            string name;
            while (true)
            {
                Console.WriteLine("Enter a name of product");
                name = Console.ReadLine();

                if (name is { } && !products.Any(p => p.Name == name))
                    break;
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("The product with this name is already exists");
                Console.ResetColor();
            }

            Console.WriteLine("Choose category of a product");
            foreach (var categoryName in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine(categoryName);
            }

            Category category;
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out category))
                    break;
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This category does not exist");
                Console.ResetColor();
            }

            Console.WriteLine("Write a description");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a price of product");
            decimal price;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out price) && price > 0) 
                    break;
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong price input");
                Console.ResetColor();
            }
            
            var product = new Product(name, price, description, category);

            Console.WriteLine("You successfully added a new product");
            
            return adminController;
        }
    }
}