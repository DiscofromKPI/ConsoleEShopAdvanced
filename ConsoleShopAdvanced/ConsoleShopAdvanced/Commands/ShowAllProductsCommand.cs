using System;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class ShowAllProductsCommand : CommandBase
    {
        public override string Name => "show";
        public override string Description => "Show all products for sale";

        public override Controller Execute<T>(T controller)
        {
            var products = GoodRepo.Products;
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            return controller;
        }
    }
}