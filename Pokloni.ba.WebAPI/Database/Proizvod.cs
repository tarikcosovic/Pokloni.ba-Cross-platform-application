﻿using Pokloni.ba.Model.Requests.Proizvodi;
using System;
using System.Collections.Generic;

namespace Pokloni.ba.WebAPI.Database
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            Ocjena = new HashSet<Ocjena>();
            NarudzbaDetails = new HashSet<NarudzbaDetails>();
        }

        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
        public int ProizvodacId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
        public int StanjeNaLageru { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaMinimised { get; set; }

        public virtual Kategorija Kategorija { get; set; }
        public virtual ProizvodacPoklona Proizvodac { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<NarudzbaDetails> NarudzbaDetails { get; set; }
    }
}
