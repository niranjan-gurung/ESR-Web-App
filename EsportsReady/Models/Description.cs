using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsportsReady.Models
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }              // foreign key to principle model (product)
        public Product Product { get; set; } = null!;   // ref/navigation to principle

        public string? CPU { get; set; }
        public string? GPU { get; set; }
        public string? Memory { get; set; }
        public string? Motherboard { get; set; }
        public string? Storage { get; set; }
        public string? PSU { get; set; }
    }
}
