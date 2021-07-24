using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class ChangeUserInfoCommand : CommandBase
    {
        public override string Name => "change user info";
        public override string Description => "Change the info of a user";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is AdminController adminController))
                return controller;

            while (true)
            {
                Console.WriteLine("1. Change customer's info");
                Console.WriteLine("0. Go back");

                int key;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 0 && key <= 1)
                        break;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input");
                    Console.ResetColor();
                }

                switch (key)
                {
                    case 1:
                        var customer = GetUser();
                        var customerController = new UserController(customer);
                        ChangeInfo(customerController);
                        break;

                    case 0:
                        return adminController;
                }
            }
        }
        
        private static User GetUser()
        {
            while (true)
            {
                Console.WriteLine("Enter user's login");
                var login = Console.ReadLine();
                var customer = UserRepo.Users.FirstOrDefault(c => c.Login == login);

                if (customer is { })
                    return customer;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Customer with this login was not found");
                Console.ResetColor();
            }
        }
        
        private static void ChangeInfo(UserController userController)
        {
            Console.WriteLine(userController.CurrentUser);
            
            while (true)
            {
                Console.WriteLine("1. Change name"); 
                Console.WriteLine("2. Change email"); 
                Console.WriteLine("3. Change phone number"); 
                Console.WriteLine("4. Change address");

                int key;

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 4) 
                        break;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input");
                    Console.ResetColor();
                }

                switch (key)
                {
                    case 1:
                        ChangeName(userController);
                        break;
                    
                    case 2:
                        ChangeEmail(userController);
                        break;
                    
                    case 3:
                        ChangePhoneNumber(userController);
                        break;
                    
                    case 4:
                        ChangeAddress(userController);
                        break;
                }

                break;
            }
        }

        private static void ChangeAddress(UserController userController)
        {
            while (true)
            {
                Console.WriteLine("Enter a first and second name");
                var address = Console.ReadLine();

                if (address is { })
                {
                    userController.CurrentUser.Address = address;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }

        private static void ChangePhoneNumber(UserController userController)
        {
            while (true)
            {
                Console.WriteLine("Enter a phone number");
                var number = Console.ReadLine();

                var pattern = @"/^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$/";
                if (number is { } && Regex.IsMatch(number, pattern))
                {
                    userController.CurrentUser.PhoneNumber = number;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }

        private static void ChangeEmail(UserController userController)
        {
            while (true)
            {
                Console.WriteLine("Enter an email");
                var email = Console.ReadLine();

                try
                {
                    if (email is { })
                        _ = new MailAddress(email);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Incorrect date of birth");
                    Console.ResetColor();
                }

                userController.CurrentUser.Email = email;

                break;
            }
        }

        private static void ChangeName(UserController userController)
        {
            while (true)
            {
                Console.WriteLine("Enter a first and second name");
                var name = Console.ReadLine();

                var pattern = @"[a-zA-Z]";
                if (name is { } && Regex.IsMatch(name, pattern))
                {
                    userController.CurrentUser.Name = name;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }
    }
}