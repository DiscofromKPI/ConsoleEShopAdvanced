using System.Collections.Generic;
using ConsoleShopAdvanced.Commands;

namespace ConsoleShopAdvanced.Controllers
{
    public class NewUserController : Controller
    {
        public override List<CommandBase> Commands { get; } = new List<CommandBase>
        {
            new FindProductCommand(),
            new HelpCommand(),
            new RegisterCommand(),
            new LoginCommand(),
            new ShowAllProductsCommand()
        };
    }
}