using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Artista
    {
        [Key]
        public int ArtistaID { get; set; }

        public string Img { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        public bool Banda { get; set; }
    }
}