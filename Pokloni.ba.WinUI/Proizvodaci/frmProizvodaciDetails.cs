﻿using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokloni.ba.WinUI.Proizvodaci
{
    public partial class frmProizvodaciDetails : MyMaterialForm
    {
        private readonly APIService _apiService = new APIService(Properties.Settings.Default.RouteProizvodaci);
        private int? _id;
        byte[] _slika;
        public frmProizvodaciDetails(int id)
        {
            InitializeComponent();
            InitialiseMyMaterialDesign(this);

            _id = id;
        }

        private async void FrmProizvodaciDetails_Load(object sender, EventArgs e)
        {
            var result = await _apiService.GetbyId<Model.Requests.Proizvodi.ProizvodacPoklona>(_id);

            Naziv.Text = result.Naziv;
            Opis.Text = result.Opis;
            _slika = result.Slika;

            MemoryStream ms = new MemoryStream(_slika);
            if(_slika != null && _slika.Length > 3)
                pictureBox1.Image = Image.FromStream(ms);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Da li ste sigurni da želite izbrisati proizvođača?", "Brisanje proizvođača!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                await _apiService.Delete(_id);
                this.Close();
                MessageBox.Show("Uspješno ste izbrisali proizvođača..", "Uspjeh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void Sacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.ValidateTextBoxes(new MaterialSingleLineTextField[1] { Naziv }, errorProvider1) && _id.HasValue)
            {
                Model.Requests.Proizvodi.ProizvodacPoklona model = new Model.Requests.Proizvodi.ProizvodacPoklona()
                {
                    ProizvodacPoklonaId = (int)_id,
                    Naziv = Naziv.Text,
                    Opis = Opis.Text,
                    Slika = _slika
                };

                await _apiService.Update<Model.Requests.Proizvodi.ProizvodacPoklona>(model, _id);
                MessageBox.Show("Uspješno ste ažurirali proizvođača..", "Uspjeh!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);
                _slika = file;

                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;

            }
        }
    }
}
