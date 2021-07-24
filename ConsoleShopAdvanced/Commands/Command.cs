using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced.Commands
{
    public abstract class CommandBase
    {
        public virtual string Name { get; }
        
        public virtual string Description { get; }

        public abstract Controller Execute<T>(T controller)
            where T : Controller;
    }
}