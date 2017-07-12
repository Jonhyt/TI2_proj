using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TI2_proj.Models
{
    public class Mood
    {
        public Mood()
        {
            Musicas = new HashSet<MusicaMood>();
        }

        [Key]
        public int MoodID { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<MusicaMood> Musicas { get; set; }

        public string Dono { get; set; }

    }
}