using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Musicas
    {
        [Key]
        public int MusicaID { get; set; }

        public string Titulo { get; set; }

        public int Duracao { get; set; }

        public Album Alb { get; set; }
    }
}