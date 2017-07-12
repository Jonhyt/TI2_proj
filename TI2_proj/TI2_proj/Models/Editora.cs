using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        public string Dono { get; set; }
    }
}