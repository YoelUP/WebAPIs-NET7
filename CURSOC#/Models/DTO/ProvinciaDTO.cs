using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURSOC_.Models.DTO
{
    public class ProvinciaDTO
    {
        [Required]
        [MaxLength(20)]
        public string? nomprovincia { get; set; }
    }
}
