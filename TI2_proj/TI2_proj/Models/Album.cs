using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class Album
    {
        public Album()
        {
            Musicas = new HashSet<ArtistaMusica>();
        }

        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }

        [Required]
        public Artista Autor { get; set; }
        [ForeignKey("Autor")]
        public int AutorFK { get; set; }

        public Editora Edit { get; set; }
        [ForeignKey("Edit")]
        public int EditFK { get; set; }

        public string Dono { get; set; }

        public virtual ICollection<ArtistaMusica> Musicas { get; set; }

    }
}