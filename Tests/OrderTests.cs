using System.Collections.Generic;
using System.Linq;
using ConsoleShopLow.Models;
using ConsoleShopLow.Repositories;
using NUnit.Framework;
using Moq;

namespace Tests
{
    public class OrderTests
    {
        private readonly List<ProductOrder> _productOrders = new List<ProductOrder>();

        [SetUp]
        public void SetUp()
        {
            const int elementsInCollection = 2;
            var products = new List<Good>();
            for (int i = 0; i < elementsInCollection; i++)
            {
                products.Add(GoodRepo.Products.ElementAt(i));
            }

            for (var i = 0; i < elementsInCollection; i++)
            {
                _productOrders.Add(new ProductOrder(products[i], i));
            }
        }

        [Test]
        public void Constructor_ReturnsCollectionWithNewElements()
        {
            var order = new Order(_productOrders);

            var result = order.Products;

            Assert.AreEqual(_productOrders, result);
        }

        [Test]
        public void AddProductOrder_ReturnsSameProductsList()
        {
            var order = new Order();

            foreach (var productOrder in _productOrders)
            {
                order.AddProductOrder(productOrder);
            }

            Assert.AreEqual(_productOrders, order.Products);
        }
    }

}