﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Musicas
    {
        public Musicas()
        {
            Artistas = new HashSet<ArtistaMusica>();
            Moods = new HashSet<MusicaMood>();
            Generos = new HashSet<MusicaGenero>();
            Compositores = new HashSet<CompositorMusica>();

        }

        [Key]
        public int MusicaID { get; set; }

        public string Titulo { get; set; }

        public int Duracao { get; set; }

        public Album Album { get; set; }
        [ForeignKey("Album")]
        public int AlbumFK { get; set; }

        public virtual ICollection<ArtistaMusica> Artistas { get; set; }
        public virtual ICollection<MusicaMood> Moods { get; set; }
        public virtual ICollection<MusicaGenero> Generos { get; set; }
        public virtual ICollection<CompositorMusica> Compositores { get; set; }


    }
}