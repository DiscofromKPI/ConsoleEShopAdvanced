using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class ChangeOrderStatusCommand : CommandBase
    {
        public override string Name => "change status";
        public override string Description => "Change order status of a customer's order";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is AdminController adminController))
                return controller;

            User user;
            while (true)
            {
                Console.WriteLine("Enter a customer's login");
                var login = Console.ReadLine();

                user = UserRepo.Users.FirstOrDefault(c => c.Login == login);

                if (user is { })
                    break;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("There is no user with such login");
                Console.ResetColor();
            }

            var placedOrders = user.PlacedOrders;
            Console.WriteLine("Customer orders: ");
            for (int i = 0; i < placedOrders.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {placedOrders.ElementAt(i)} - {placedOrders.ElementAt(i).Status}");
            }

            Console.WriteLine("Enter a number of order you want to change");
            int key;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= placedOrders.Count())
                    break;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input");
                Console.ResetColor();
            }

            var order = placedOrders.ElementAt(key - 1);
            ChangeStatus(order);

            return adminController;
        }

        private void ChangeStatus(Order order)
        {
            Console.WriteLine("Choose new category of a product");
            foreach (var categoryName in Enum.GetNames(typeof(OrderStatus)))
            {
                Console.WriteLine(categoryName);
            }

            OrderStatus status;
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out status))
                    break;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This category does not exist");
                Console.ResetColor();
            }

            order.Status = status;
        }
    }
}