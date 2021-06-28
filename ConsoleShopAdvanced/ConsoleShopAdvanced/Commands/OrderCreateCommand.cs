using ConsoleShopAdvanced.Controllers;

namespace ConsoleShopAdvanced.Commands
{
    public class OrderCreateCommand : CommandBase
    {
        public override string Name => "checkout";
        public override string Description => "Create an order";

        public override Controller Execute<T>(T controller)
        {
            if (!(controller is UserController customerController))
                return controller;

            var currentOrder = customerController.CurrentUser.CurrentOrder;

            foreach (var toOrder in customerController.CurrentUser.ToOrder)
            {
                currentOrder.Value.AddProductOrder(toOrder);
            }
            
            customerController.CurrentUser.PlaceOrder(currentOrder.Value);
           
            return customerController;
        }
    }
}