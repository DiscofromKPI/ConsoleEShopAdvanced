using System;
using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced.Commands
{
    public class ShowOrdersCommand : CommandBase
    {
        public override string Name => "show orders";
        public override string Description => "Show my orders";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is UserController customerController))
                return controller;

            foreach (var order in customerController.CurrentUser.PlacedOrders)
            {
                Console.WriteLine($"{order} - {order.Status}");
            }

            return customerController;
        }
    }
}