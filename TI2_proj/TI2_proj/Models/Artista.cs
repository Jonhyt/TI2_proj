﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TI2_proj.Models
{
    public class Artista
    {
        [Key]
        public int idArtista { get; set; }

        [Required]
        [StringLength(30)]
        public int nome { get; set; }
    }
}