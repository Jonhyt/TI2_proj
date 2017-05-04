using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TI2_proj.Models
{
    public class Bandas
    {
        //Tabela da relação muitos para muitos Banda-Membros
        //(Sendo "Banda" tratada como artista)

        [Key]
        public Artista Banda { get; set; }
        [ForeignKey("Banda")]
        public int BandaFK { get; set; }

        [Key]
        public Artista Membro { get; set; }
        [ForeignKey("Membro")]
        public int MembroFK { get; set; }
    }
}