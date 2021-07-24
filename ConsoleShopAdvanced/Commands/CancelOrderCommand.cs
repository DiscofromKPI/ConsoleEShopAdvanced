using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Commands
{
    public class CancelOrderCommand : CommandBase
    {
        public override string Name => "cancel";
        public override string Description => "Cancel an order";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is UserController customerController))
                return controller;

            var orders = customerController.CurrentUser.PlacedOrders
                .Where(o => o.Status != (OrderStatus.Completed | OrderStatus.Received));

            if (!orders.Any())
            {
                Console.WriteLine("No orders");
                return customerController;
            }

            int ordersQuantity = orders.Count();
            for (int i = 0; i < ordersQuantity; i++)
            {
                Console.WriteLine($"{i + 1}. {orders.ElementAt(i)}");
            }

            int choose;
            while (true)
            {
                Console.WriteLine("Enter a number of order you want to cancel");
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    if (choose > 0 && choose < ordersQuantity + 1)
                        break;
                }
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input");
                Console.ResetColor();
            }

            var orderToRemove = orders.ElementAt(--choose);
            customerController.CurrentUser.CancelOrder(orderToRemove);

            return customerController;
        }
    }
}