using System;
using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced.Commands
{
    public class HelpCommand : CommandBase
    {
        public override string Name => "help";
        public override string Description => "Show all available commands";

        public override Controller Execute<T>(T controller)
        {
            var commands = controller.Commands;

            Console.WriteLine("Available commands");
            foreach (var command in commands)
            {
                Console.WriteLine($"{command.Name} \t - \t {command.Description}");
            }

            return controller;
        }
    }
}