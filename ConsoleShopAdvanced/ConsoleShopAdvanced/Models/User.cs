using System;
using System.Collections.Generic;
using ConsoleShopAdvanced.Repositories;


namespace ConsoleShopAdvanced.Models
{
    public class User : RegisteredUser
    {
        private List<ProductOrder> _toOrder = new List<ProductOrder>();
        private List<Order> _placedOrders = new List<Order>();
        
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public IEnumerable<ProductOrder> ToOrder => _toOrder;
        public IEnumerable<Order> PlacedOrders => _placedOrders;

        public Lazy<Order> CurrentOrder { get; private set; } = new Lazy<Order>(() => new Order());

        public User()
        {
            UserRepo.RegisterUser(this);
        }

        public void AddProductToOrder(Product product, int quantity)
        {
            var productOrder = new ProductOrder(product, quantity);
            _toOrder.Add(productOrder);
        }

        public void CancelOrder(Order order)
        {
            _placedOrders.Remove(order);
        }

        public void ChangeStatus(Order order, OrderStatus status = OrderStatus.Received)
        {
            _placedOrders[_placedOrders.IndexOf(order)].Status = status;
        }

        public void PlaceOrder(Order order)
        {
            _placedOrders.Add(order);
            CurrentOrder = new Lazy<Order>(() => new Order());
            _toOrder = new List<ProductOrder>();
        }

        public override string ToString() =>
            $"{Name} - {BirthDate} - {Email} - {PhoneNumber} - {Address}";
    }
}