using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Commands
{
    public class OrderReceivedCommand : CommandBase
    {
        public override string Name => "receive";
        public override string Description => "Change order's status to \"Received\"";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is UserController customerController))
                return controller;

            var sentOrders = customerController.CurrentUser.PlacedOrders
                .Where(o => o.Status == OrderStatus.Sent);
            
            int ordersQuantity = sentOrders.Count();
            for (int i = 0; i < ordersQuantity; i++)
            {
                Console.WriteLine($"{i + 1}. {sentOrders.ElementAt(i)}");
            }
            
            int choose;
            while (true)
            {
                Console.WriteLine("Enter a number of order you want to tag as \"Received\"");
                if (int.TryParse(Console.ReadLine(), out choose))
                {
                    if (choose > 0 && choose < ordersQuantity + 1)
                        break;
                }
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input");
                Console.ResetColor();
            }
            
            var orderToChange = sentOrders.ElementAt(--choose);
            customerController.CurrentUser.ChangeStatus(orderToChange);

            return customerController;
        }
    }
}