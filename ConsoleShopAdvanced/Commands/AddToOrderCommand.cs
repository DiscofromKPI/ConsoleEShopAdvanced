using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class AddToOrderCommand : CommandBase
    {
        public override string Name => "add";
        public override string Description => "Add a product to order";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is UserController customerController))
                return controller;

            var products = GoodRepo.Products;
            
            while (true)
            {
                Console.WriteLine("Press y to create a new order.");
                Console.WriteLine("Press n to go back.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {   
                    case ConsoleKey.Y:
                        if (AddToOrder(products, customerController))
                            return customerController;
                        break;
                    
                    case ConsoleKey.N:
                        return customerController;
                    
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wrong key");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static bool AddToOrder(IEnumerable<Product> products, UserController userController)
        {
            Console.WriteLine("Enter a name of product");
            var name = Console.ReadLine();
            var product = products.FirstOrDefault(p => p.Name == name);

            if (product is null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Product was not found");
                Console.ResetColor();
                return false;
            }

            Console.WriteLine("Enter a quantity of product");
            int quantity;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out quantity))
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("A string is not a number");
                Console.ResetColor();
            }

            userController.CurrentUser.AddProductToOrder(product, quantity);
            Console.WriteLine("Product was successfully added");
            
            return true;
        }
    }
}