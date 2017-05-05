using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class MusicaMood
    {
        //Tabela que relaciona Musicas a generos

        public Musicas Musica { get; set; }
        [Key,Column(Order =0)]
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        public Mood Mood { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Mood")]
        public int MoodFK { get; set; }

    }
}