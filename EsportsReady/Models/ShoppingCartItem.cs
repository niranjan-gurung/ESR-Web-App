using System.ComponentModel.DataAnnotations;

namespace EsportsReady.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
