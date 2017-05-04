using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Artista
    {
        [Key]
        public int idArtista { get; set; }

        [Required]
        [StringLength(30)]
        public int nome { get; set; }
    }
}