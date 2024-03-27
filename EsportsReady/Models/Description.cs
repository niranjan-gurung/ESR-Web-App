using System.ComponentModel.DataAnnotations;

namespace EsportsReady.Models
{
    public class Description
    {
        [Key]
        public int DescriptionId { get; set; }
        public int ProductId { get; set; }
        public string? CPU { get; set; }
        public string? GPU { get; set; }
        public string? Memory { get; set; }
        public string? Motherboard { get; set; }
        public string? Storage { get; set; }
        public string? PSU { get; set; }
    }
}
