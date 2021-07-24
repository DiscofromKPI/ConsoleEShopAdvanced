using System.Collections.Generic;
using System.Linq;
using ConsoleShopLow.Models;
using ConsoleShopLow.Repositories;
using Moq;
using NUnit.Framework;


namespace Tests
{
    public class UserTests
    {
        private List<User> _users;

        [SetUp]
        public void SetUp()
        {
            _users = GetUsers();
        }
        private List<User> GetUsers()
        {
            return new List<User>()
            {
                new User {Login = "first", Password = "pass1"},
                new User {Login = "second", Password = "pass2"},
                new User {Login = "third", Password = "pass3"}
            };

        }
        [Test]
        public void CheckTheCorrectCountOfCollection()
        {
            var mockRepo = new Mock<Admin>();
            mockRepo.Setup(repo => repo.GetAllUsers()).Returns(GetUsers());
            var result = mockRepo.Object.GetAllUsers();
            Assert.AreEqual(_users.Count, result.Count);
        }

        [Test]
        public void RegisterTheCustomer_ReturnsTheCollectionWithNewCustomer()
        {
            User user = new User {Login = "customer4"};
            Register(user);
            Assert.AreEqual("customer4", _users[3].Login);
        }
        [Test]
        public void AddToOrder_ReturnsTheCollectionWithNewOrder()
        {
            Good po = GoodRepo.Products.ElementAt(0);
            _users[0].AddProductToOrder(po, 2);
            Assert.AreEqual(_users[0].ToOrder.Count(), 1);
        }

        [Test]
        public void PlaceOrder_ReturnsTheCollectionWithNewPlacedOrder()
        {
            Order order = new Order();
            _users[0].PlaceOrder(order);
            Assert.AreEqual(_users[0].PlacedOrders.Count(), 1);
        }

        [Test]
        public void PlaceOrder_ReturnsCorrectCurrentOrder()
        {
            Order order = new Order();
            _users[0].PlaceOrder(order);
            Assert.IsFalse(_users[0].CurrentOrder.IsValueCreated);
        }

        [Test]
        public void CancelOrder_ReturnsCollectionWithRemovedOrder()
        {
            Order order = new Order();
            _users[0].PlaceOrder(order);
            _users[0].CancelOrder(order);
            Assert.IsEmpty(_users[0].PlacedOrders);
        }

        [Test]
        public void ChangeStatus_ReturnsTheOrderWithCorrectChangedStatus()
        {
            Order order = new Order();
            order.Status = OrderStatus.Canceled;
            _users[0].PlaceOrder(order);
            _users[0].ChangeStatus(order);
            Assert.AreEqual(order.Status, OrderStatus.Received);
        }
        private void Register(User user)
        {
            _users.Add(user);
        }
    }
}