using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(30)]
        public int Titulo { get; set; }

        [Required]
        public Artista Autor { get; set; }

        public Editora Edit { get; set; }
    }
}