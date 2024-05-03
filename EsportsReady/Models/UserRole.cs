using System.ComponentModel.DataAnnotations;

namespace EsportsReady.Models
{
    public class UserRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
