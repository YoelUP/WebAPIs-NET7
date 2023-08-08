using System.ComponentModel.DataAnnotations;

namespace CURSO_C__WEB.Models.DTO
{
    public class ProvinciaDTO
    {
        [Required]
        [MaxLength(20)]
        public string? nomprovincia { get; set; }
    }
}
