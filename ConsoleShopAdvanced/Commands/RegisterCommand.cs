using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ConsoleShopAdvanced.Controllers;
using ConsoleShopAdvanced.Models;
using ConsoleShopAdvanced.Repositories;

namespace ConsoleShopAdvanced.Commands
{
    public class RegisterCommand : CommandBase
    {
        public override string Name => "register";
        public override string Description => "Register a new customer";

        public override Controller Execute<T>(T controller)
        {
            var customer = new User();
            
            CreateLogin(customer);
            CreatePassword(customer);
            CreateName(customer);
            CreateBirthDate(customer);
            CreateEmail(customer);
            CreatePhoneNumber(customer);
            CreateAddress(customer);

            Console.WriteLine("You successfully registered");
            
            return new UserController(customer);
        }

        private static void CreateAddress(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter your address");
                var address = Console.ReadLine();

                if (address is { })
                {
                    user.Address = address;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }

        private static void CreatePhoneNumber(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter a phone number");
                var number = Console.ReadLine();

                var pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
                if (number is { } && Regex.IsMatch(number, pattern))
                {
                    user.PhoneNumber = number;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect phone number");
                Console.ResetColor();
            }
        }

        private static void CreateEmail(User user)
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

                user.Email = email;

                break;
            }
        }

        private static void CreateBirthDate(User user)
        {
            DateTime birthDate;
            
            while (true)
            {
                Console.WriteLine("Enter a date of birth");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate)
                    && DateTime.Now.Year - birthDate.Year < 105 && DateTime.Now.Year - birthDate.Year > 6)
                {
                    user.BirthDate = birthDate;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect date of birth");
                Console.ResetColor();
            }
        }

        private static void CreateName(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter a first and second name");
                var name = Console.ReadLine();

                var pattern = @"[a-zA-Z]";
                if (name is { } && Regex.IsMatch(name, pattern))
                {
                    user.Name = name;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect name");
                Console.ResetColor();
            }
        }

        private static void CreatePassword(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter a password");
                var password = Console.ReadLine();

                var pattern = @"^(.{0,7}|[^0-9]*|[^A-Z])$";
                if (!(password is { } && Regex.IsMatch(password, pattern)))
                {
                    continue;
                }

                Console.WriteLine("Enter the same password");
                var checkPass = Console.ReadLine();

                if (checkPass == password)
                {
                    user.Password = password;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect password");
                Console.ResetColor();
            }
        }

        private static void CreateLogin(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter a login");
                var login = Console.ReadLine();

                if (UserRepo.Users.Any(c => c.Login == login))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("The user with this login is already exists");
                    Console.ResetColor();

                    continue;
                }

                var pattern = "^[a-zA-Z0-9]+$";
                if (login is { } && Regex.IsMatch(login, pattern))
                {
                    user.Login = login;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Incorrect login");
                Console.ResetColor();
            }
        }
    }
}