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

        [Key]
        public int MusGenID { get; set; }

        public Musicas Musica { get; set; }
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        public Mood Mood { get; set; }
        [ForeignKey("Mood")]
        public int MoodFK { get; set; }

    }
}