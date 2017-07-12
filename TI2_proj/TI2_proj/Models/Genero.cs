using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Genero
    {
        public Genero()
        {
            Musicas = new HashSet<MusicaGenero>();
        }

        [Key]
        public int GeneroID { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<MusicaGenero> Musicas { get; set; }

        public string Dono { get; set; }
    }
}