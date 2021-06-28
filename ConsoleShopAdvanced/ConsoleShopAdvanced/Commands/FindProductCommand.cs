using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class FindProductCommand : CommandBase
    {
        public override string Name => "find";
        public override string Description => "Find a product by name";

        public override Controller Execute<T>(T controller)
        {
            var products = GoodRepo.Products;

            while (true)
            {
                Console.WriteLine("Enter a product name");
                var name = Console.ReadLine();

                var product = products.FirstOrDefault(pr => pr.Name == name);

                if (product is { })
                {
                    Console.WriteLine(product);
                    return controller;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }
    }
}