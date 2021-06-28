using System.Collections.Generic;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Repositories
{
    public static class GoodRepo
    {
        private static List<Product> _products = new List<Product>();

        public static IEnumerable<Product> Products => _products;

        static GoodRepo() => Create();

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        
        private static void Create()
        {
            var products = new Product[]
            {
                new Product("Banana", 5, "Fruit", Category.Fruit),
                new Product("Beer", 23, "Some tasty thing", Category.Drink),
                new Product("Sausage", 46, "From pig", Category.Meat),
                new Product("Water", 330, "From ocean", Category.Drink),
                new Product("Carp", 433, "With love from Dnipro", Category.Fish),
                new Product("crucian", 500, "from the river", Category.Fish)
            };
        }
    }
}

