using System;
using System.Collections.Generic;
using ConsoleShopAdvanced.Commands;
using ConsoleShopAdvanced.Models;

namespace ConsoleShopAdvanced.Controllers
{
    public class  UserController : Controller
    {
        public User CurrentUser { get; set; }
        
        public override List<CommandBase> Commands { get; } = new List<CommandBase>
        {
            new AddToOrderCommand(),
            new CancelOrderCommand(),
            new ChangePersonalInfoCommand(),
            new FindProductCommand(),
            new HelpCommand(),
            new LoginCommand(),
            new LogOutCommand(),
            new OrderCreateCommand(),
            new OrderReceivedCommand(),
            new ShowOrdersCommand()
        };

        public UserController(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            CurrentUser = user;
        }
    }
}