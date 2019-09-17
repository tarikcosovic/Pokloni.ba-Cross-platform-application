﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokloni.ba.WinUI.Proizvodi
{
    public partial class frmProizvodiInsert : MyMaterialForm
    {
        private readonly APIService _apiServiceProizvodi = new APIService(Properties.Settings.Default.RouteProizvodi);

        private readonly APIService _apiServiceKategorije = new APIService(Properties.Settings.Default.RouteKategorije);
        private readonly APIService _apiServiceProizvodaci = new APIService(Properties.Settings.Default.RouteProizvodaci);
        public frmProizvodiInsert()
        {
            InitializeComponent();
            InitialiseMyMaterialDesign(this);
        }

        private async void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            MaterialSingleLineTextField[] temp = new MaterialSingleLineTextField[2] { Naziv, Sifra};
            if (ValidationHelper.ValidateTextBoxes(temp, errorProvider))
            {
                var ComboBoxKategorija = Kategorija.SelectedItem;
                var ComboBoxProizvodac = Proizvodac.SelectedItem;
                var model = new Model.Requests.Proizvodi.ProizvodVM()
                {
                    Naziv = Naziv.Text,
                    Sifra = Sifra.Text,
                    Opis = Opis.Text,
                    Cijena = int.Parse(Cijena.Text),
                    StanjeNaLageru = int.Parse(StanjeNaLageru.Text),
                    KategorijaId = ((Model.Requests.Proizvodi.Kategorije)ComboBoxKategorija).KategorijaId,
                    ProizvodacId = ((Model.Requests.Proizvodi.ProizvodacPoklona)ComboBoxProizvodac).ProizvodacPoklonaId
                };

                await _apiServiceProizvodi.Insert<Model.Requests.Proizvodi.ProizvodVM>(model);

                MessageBox.Show("Uspješno ste dodali proizvod..", "Uspjeh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private async Task LoadKategorije()
        {
            var result = await _apiServiceKategorije.Get<List<Model.Requests.Proizvodi.Kategorije>>();
            result.Insert(0, new Model.Requests.Proizvodi.Kategorije() { KategorijaId = 0 });

            Kategorija.DataSource = result;
            Kategorija.DisplayMember = "Naziv";
            Kategorija.Tag = "UlogaId";
        }

        private async Task LoadProizvodac()
        {
            var result = await _apiServiceProizvodaci.Get<List<Model.Requests.Proizvodi.ProizvodacPoklona>>();
            result.Insert(0, new Model.Requests.Proizvodi.ProizvodacPoklona() { ProizvodacPoklonaId = 0 });

            Proizvodac.DataSource = result;
            Proizvodac.DisplayMember = "Naziv";
            Proizvodac.Tag = "UlogaId";
        }

        private async void FrmProizvodiInsert_Load(object sender, EventArgs e)
        {
            await LoadKategorije();
            await LoadProizvodac();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            var vrijednost = int.Parse(StanjeNaLageru.Text);
            ++vrijednost;

            StanjeNaLageru.Text = vrijednost.ToString();
        }

        private void PictureBox5_Click_1(object sender, EventArgs e)
        {
            var vrijednost = int.Parse(StanjeNaLageru.Text);
            --vrijednost;

            StanjeNaLageru.Text = vrijednost.ToString();

        }
    }
}
