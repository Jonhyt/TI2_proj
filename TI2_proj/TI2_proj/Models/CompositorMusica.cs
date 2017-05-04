using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class CompositorMusica
    {
        //Tabela da relação muitos para muitos que relata a relação
        //muitos para muitos entre as musicas e os seus compositores
        //("Compositores" são artistas)

        [Key]
        public Musicas Musica { get; set; }
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        [Key]
        public Artista Compositor { get; set; }
        [ForeignKey("Compositor")]
        public int CompositorFK { get; set; }
    }
}