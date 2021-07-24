using System;
using System.Linq;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Repositories;


namespace ConsoleShopAdvanced.Commands
{
    // TODO: Add opportunity to leave a login menu.
    public class LoginCommand : CommandBase
    {
        public override string Name => "login";
        public override string Description => "Login into account";

        public override Controller Execute<T>(T controller)
        {
            while (true)
            {
                Console.WriteLine("Enter a login");
                var login = Console.ReadLine();

                Console.WriteLine("Enter a password");
                var password = Console.ReadLine();

                var customer = UserRepo.Users
                    ?.FirstOrDefault(c => c.Login == login && c.Password == password);

                if (customer is { })
                {
                    Console.WriteLine("You successfully logged in");
                    return new UserController(customer);
                }

                var admin = AdminRepo.Admins.
                    FirstOrDefault(c => c.Login == login && c.Password == password);

                if (admin is { })
                {
                    Console.WriteLine("You successfully logged in as administrator");
                    return new AdminController();
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect login or password");
                Console.ResetColor();
            }
        }
    }
}