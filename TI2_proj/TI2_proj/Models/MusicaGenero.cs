using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class MusicaGenero
    {
        //Tabela que relaciona Musicas a generos
        [Key]
        public int MusGenID { get; set; }

        public Musicas Musica { get; set; }
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        public Genero Genero { get; set; }
        [ForeignKey("Genero")]
        public int GeneroFK { get; set; }

        public string Dono { get; set; }
    }
}