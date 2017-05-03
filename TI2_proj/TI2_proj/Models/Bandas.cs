using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Bandas
    {
        [Key]
        public Artista Banda { get; set; }

        [Key]
        public Artista Membro { get; set; }
    }
}