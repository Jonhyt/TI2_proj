using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class CompositorMusica
    {
        //Tabela da relação muitos para muitos que relata a relação
        //muitos para muitos entre as musicas e os seus compositores
        //("Compositores" são artistas)

        public Musicas Musica { get; set; }
        [Key, Column(Order = 0)]
        [ForeignKey("Musica")]
        public int MusicaFK { get; set; }

        public Artista Compositor { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Compositor")]
        public int CompositorFK { get; set; }
    }
}