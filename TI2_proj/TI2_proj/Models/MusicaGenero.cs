using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class MusicaGenero
    {
        //Tabela que relaciona Musicas a generos

        public Musicas Musica { get; set; }
        [Key, Column(Order = 0)]
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        public Musicas Genero { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Genero")]
        public int GeneroFK { get; set; }
    }
}