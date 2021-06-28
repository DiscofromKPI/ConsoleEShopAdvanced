using System;
using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced.Commands
{
    public class LogOutCommand : CommandBase
    {
        public override string Name => "log out";
        public override string Description => "Log out from account";

        public override Controller Execute<T>(T controller)
        {
            Console.WriteLine("You have successfully logged out");
            return new NewUserController();
        }
    }
}