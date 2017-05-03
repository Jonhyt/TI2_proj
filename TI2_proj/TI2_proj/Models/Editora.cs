using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Editora
    {
        [Key]
        public int EditoraId { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}