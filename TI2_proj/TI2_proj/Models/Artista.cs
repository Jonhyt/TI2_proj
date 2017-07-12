using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Artista
    {
        public Artista()
        {
            if (Banda)
            {
                Membros = new HashSet<Bandas>();
                Albuns = new HashSet<Album>();
            }
        }

        [Key]
        public int ArtistaID { get; set; }

        public string Img { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        public bool Banda { get; set; }

        public string Dono { get; set; }

        public ICollection<Bandas> Membros;
        public ICollection<Album> Albuns;
    }
}