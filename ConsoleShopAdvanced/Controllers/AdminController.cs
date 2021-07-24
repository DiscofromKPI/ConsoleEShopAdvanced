using System.Collections.Generic;
using ConsoleShopAdvanced.Commands;

namespace ConsoleShopAdvanced.Controllers
{
    public class AdminController : Controller
    {
        public override List<CommandBase> Commands { get; }= new List<CommandBase>
        {
            new AddProductCommand(),
            new ChangeOrderStatusCommand(),
            new ChangeProductInfoCommand(),
            new ChangeUserInfoCommand(),
            new FindProductCommand(),
            new HelpCommand(),
            new LoginCommand(),
            new LogOutCommand(),
            new ShowAllCustomersCommand(),
            new ShowAllProductsCommand(),
        };
    }
}