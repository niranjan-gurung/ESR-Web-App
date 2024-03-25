using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EsportsReady.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage="Title length has exceeded 20 characters.")]
        public string? Title { get; set; }
        [Range(1, 5000)]    // not needed really..
        public int Price { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Description length has exceeded 1000 characters.")]
        public string? Description { get; set; }
        //public Category Category { get; set; }
    }
}
