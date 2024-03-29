﻿using System;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using System.Collections.Generic;

namespace Pokloni.ba.WinUI.Korisnici
{
    public partial class frmKorisnici : MyMaterialForm
    {
        private readonly APIService _apiService = new APIService(Properties.Settings.Default.RouteKorisnici);
        public frmKorisnici()
        {
            InitializeComponent();

            InitialiseMyMaterialDesign(this);
        }

        private async void BtnPrikazi_Click(object sender, EventArgs e)
        {
            var queries = txtPretraga.Text;
            var result = await _apiService.Get<IEnumerable<Model.Korisnik>>("Username", queries);

            listaKorisnika.Items.Clear();
            foreach (var item in result)
            {
                ListViewItem temp = new ListViewItem();
                temp.SubItems.Add(item.Username);
                temp.SubItems.Add(item.Email);
                if (item.DatumZadnjegLogiranja != null && DateTime.Compare(DateTime.Now.AddMonths(-1), (DateTime)item.DatumZadnjegLogiranja) > 0)
                    item.Status = false;
                else item.Status = true;
                if(item.Status)
                    temp.SubItems.Add("Aktivan");
                else
                    temp.SubItems.Add("Neaktivan");
                temp.SubItems.Add(item.Uloga.Naziv);
                temp.Tag = item.KorisnikDetailsId.ToString();

                listaKorisnika.Items.Add(temp);
            }
        }

        private void ListaKorisnika_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = listaKorisnika.SelectedItems[0].Tag.ToString();

            frmKorisniciDetalji frm = new frmKorisniciDetalji(int.Parse(id));
            frm.Show();
        }

        private void FrmKorisnici_Load(object sender, EventArgs e)
        {
            BtnPrikazi_Click(null, null);
        }
    }
}
