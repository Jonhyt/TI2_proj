using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class ArtistaMusica
    {
        [Key]
        public Musicas Musica { get; set; }
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        [Key]
        public Artista Artista { get; set; }
        [ForeignKey("Artista")]
        public int ArtistaFK { get; set; }
    }
}