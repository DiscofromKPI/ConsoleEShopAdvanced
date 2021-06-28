using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class ChangeProductInfoCommand : CommandBase
    {
        public override string Name => "change product";
        public override string Description => "Change information about a product";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is AdminController adminController))
                return controller;

            var products = GoodRepo.Products;
            
            while (true)
            {
                Console.WriteLine("1. Change customer's info");
                Console.WriteLine("0. Go back");

                int key;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 0 && key <= 1)
                        break;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input");
                    Console.ResetColor();
                }

                switch (key)
                {
                    case 1:
                        var product = GetProduct();
                        ChangeInfo(products, product);

                        break;

                    case 0:
                        return adminController;
                }
            }
        }
        
        private static Product GetProduct()
        {
            while (true)
            {
                Console.WriteLine("Enter product's name");
                var name = Console.ReadLine();
                var product = GoodRepo.Products.FirstOrDefault(p => p.Name == name);

                if (product is { })
                    return product;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Product with this name was not found");
                Console.ResetColor();
            }
        }

        private void ChangeInfo(IEnumerable<Product> products, Product product)
        {
            while (true)
            {
                Console.WriteLine("1. Change name"); 
                Console.WriteLine("2. Change category"); 
                Console.WriteLine("3. Change price"); 
                Console.WriteLine("4. Change description");

                int key;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 4) 
                        break;
                    
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input");
                    Console.ResetColor();
                }

                switch (key)
                {
                    case 1:
                        string name;
                        while (true)
                        {
                            name = Console.ReadLine();

                            if (name is { } && !products.Any(p => p.Name == name))
                                break;
                
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("The product with this name is already exists");
                            Console.ResetColor();
                        }

                        product.Name = name;
                        break;
                    
                    case 2:
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

                        product.Category = category;
                        break;
                    
                    case 3:
                        decimal price;
                        while (true)
                        {
                            if (decimal.TryParse(Console.ReadLine(), out price) && price > 0) 
                                break;
                
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Wrong price input");
                            Console.ResetColor();
                        }

                        product.Price = price;
                        break;
                    
                    case 4:
                        Console.WriteLine("Write a description");
                        string description = Console.ReadLine();

                        product.Description = description;
                        break;
                }
            }
        }
    }
}