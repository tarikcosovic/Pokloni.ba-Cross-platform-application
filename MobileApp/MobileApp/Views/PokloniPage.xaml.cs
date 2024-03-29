﻿using MobileApp.ViewModels;
using System;
using Pokloni.ba.Model.Requests.Proizvodi;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokloniPage : ContentPage
    {
        private readonly PokloniViewModel model = null;
        private bool OpenedOnce = false;
        private int _kategorija = 0;
        public PokloniPage(int kategorija = 0)
        {
            InitializeComponent();
            BindingContext = model = new PokloniViewModel();
            _kategorija = kategorija;
        }

        protected override void OnAppearing()
        {
            if(!OpenedOnce)
            {
                model.LoadList(proizvodiListView, KategorijePicker, _kategorija);
                OpenedOnce = true;
            }
            KorpaCounter.Text = KorpaViewModel.ListaKorpe.Count.ToString();
            base.OnAppearing();
        }

        protected void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(KategorijePicker.SelectedItem != null)
            {
                model.LoadFilteredList(proizvodiListView, (KategorijePicker.SelectedItem as Kategorije).KategorijaId); 
            }
        }

        private void ProizvodiListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                this.Navigation.PushAsync(new PokloniDetails(e.Item as ProizvodVM));
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var clicked = e as TappedEventArgs;
            model.DodajUKorpu(clicked.Parameter as ProizvodVM);
            DisplayAlert("Hvala!", "Uspješno ste dodali " + ((ProizvodVM)(clicked.Parameter)).Naziv + " u vašu korpu!", "ok");
            KorpaCounter.Text = KorpaViewModel.ListaKorpe.Count.ToString();
         }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new KorpaPage());
        }
    }
}