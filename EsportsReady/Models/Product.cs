using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsReady.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage="Title length has exceeded 20 characters.")]
        public string? Title { get; set; }
        public string? Image { get; set; }
        [Range(1, 5000)]    // not needed really..
        public int Price { get; set; }
        public Description Description { get; set; } = null!;   // ref/navigation to dependant (description)
    }
}
