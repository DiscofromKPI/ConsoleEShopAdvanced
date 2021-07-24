using System;
using System.Linq;
using ConsoleShopAdvanced.Commands;
using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced
{
    class Program
    {
        private static void Main(string[] args)
        {
            Controller controller = new NewUserController();
            new HelpCommand().Execute(controller);

            while (true)
            {
                Console.Write("> ");
                var str = Console.ReadLine();
                if (str == "exit")
                    break;
                var command = controller.Commands.FirstOrDefault(x => x.Name == str);

                if (command == null)
                {
                    Console.WriteLine("Command not found, help");
                    continue;
                }
                controller = command.Execute(controller);
            }
        }
    }
}