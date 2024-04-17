namespace EsportsReady.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> CartItems { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}
