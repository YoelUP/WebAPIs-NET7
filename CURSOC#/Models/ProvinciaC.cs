using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURSOC_.Models
{
    public class ProvinciaC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int conprovincia { get; set; }

        public string? nomprovincia { get; set; }
    }
}
