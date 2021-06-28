namespace ConsoleShopAdvanced.Models
{
    public class ProductOrder
    {
        public Product Product { get; }
        
        public int Quantity { get; }

        public decimal TotalPrice => Product.Price * Quantity;

        public ProductOrder(Product product, int quantity) =>
            (Product, Quantity) = (product, quantity);

        public override string ToString() =>
            $"{Product} - {Quantity}";
    }
}