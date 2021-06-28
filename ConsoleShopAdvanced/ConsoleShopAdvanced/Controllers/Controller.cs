using System.Collections.Generic;
using ConsoleShopAdvanced.Commands;

namespace ConsoleShopAdvanced.Controllers
{
    public abstract class Controller
    {
        public abstract List<CommandBase> Commands { get; }
    }
}