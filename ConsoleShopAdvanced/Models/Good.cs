using System;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Models
{
    public enum Category
    {
        Fruit,
        Drink,
        Vegetable,
        Meat, 
        Fish
    }
    public class Product
    {
        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public Category Category { get; set; }
        
        public string Description { get; set; }

        public Product(string name, decimal price, string description, Category category)
        {
            _ = name ?? throw new ArgumentNullException(nameof(name));
            _ = description ?? throw new ArgumentNullException(nameof(description));
            
            Name = name;
            Price = price;
            Description = description;
            Category = category;
            
            GoodRepo.AddProduct(this);
        }

        public override string ToString() =>
            $"{Name} - {Price} - {Category} - {Description}";
    }
}