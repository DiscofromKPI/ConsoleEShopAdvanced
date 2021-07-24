using System;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class ShowAllCustomersCommand : CommandBase
    {
        public override string Name => "show users";
        public override string Description => "Show all registered users";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is AdminController adminController))
                return controller;

            var customers = UserRepo.Users;
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Login);
            }

            return adminController;
        }
    }
}