using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleShopAdvanced.Models
{
    [Flags]
    public enum OrderStatus
    {
        New,
        Paid,
        Sent,
        Received,
        Completed,
        Canceled
    }
    
    public class Order
    {
        private List<ProductOrder> _products = new List<ProductOrder>();

        public OrderStatus Status { get; set; } = OrderStatus.New;

        public IEnumerable<ProductOrder> Products => _products;
        
        public Order() { }
        
        public Order(IEnumerable<ProductOrder> products)
        {
            _products = products.ToList();
        }

        public void AddProductOrder(ProductOrder productOrder)
        {
            _products.Add(productOrder);
        }

        public override string ToString()
        {
            var names = string.Join(", ", _products);
            return names;
        }
    }
}