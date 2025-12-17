namespace WebShopApp.Models.Cart
{
    public class CartItemVM
    {
        public int Id { get; set; } //ProductId
        public string? ProductName { get; set; }
        public string? Picture { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total => Price * Quantity;
    }
}
