using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class MusicaGenero
    {
        //Tabela que relaciona Musicas a generos

        [Key]
        public Musicas Musica { get; set; }
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        [Key]
        public Musicas Genero { get; set; }
        [ForeignKey("Genero")]
        public int GeneroFK { get; set; }
    }
}