using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class Bandas
    {
        //Tabela da relação muitos para muitos Banda-Membros
        //(Sendo "Banda" tratada como artista)

        public Artista Banda { get; set; }
        [Key, Column(Order = 0)]
        [ForeignKey("Banda")]
        public int BandaFK { get; set; }

        public Artista Membro { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Membro")]
        public int MembroFK { get; set; }
    }
}