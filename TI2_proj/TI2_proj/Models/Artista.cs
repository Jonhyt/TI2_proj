using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Artista
    {
        [Key]
        public int idArtista { get; set; }

        public string Img { get; set; }

        [Required]
        [StringLength(30)]
        public string nome { get; set; }

        [Required]
        public bool banda { get; set; }
    }
}