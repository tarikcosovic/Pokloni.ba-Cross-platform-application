﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pokloni.ba.Model.Requests.Proizvodi
{
    public class ProizvodacPoklona
    {
        public int ProizvodacPoklonaId { get; set; }
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Naziv { get; set; }
        [MinLength(1), MaxLength(1000)]
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaMinimised { get; set; }

    }
}
