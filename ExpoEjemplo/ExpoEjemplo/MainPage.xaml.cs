﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExpoEjemplo.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using ExpoEjemplo.ViewModel;

namespace ExpoEjemplo
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            string Url = "http://127.0.0.1:8000/api/players";
            HttpClient client = new HttpClient();
            ObservableCollection<Player> _post;

            string content = await client.GetStringAsync(Url);
            List<Player> posts = JsonConvert.DeserializeObject<List<Player>>(content);
            _post = new ObservableCollection<Player>(posts);
            PlayerList.ItemsSource = _post;
            base.OnAppearing();
        }

        private void Insert(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Create());
        }
        private void Update(object sender, EventArgs e)
        {
            var player = (Player)((Button)sender).BindingContext;
            Navigation.PushAsync(new Update(player));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var player = (Player)((Button)sender).BindingContext;
            HttpClient client = new HttpClient();
            string JsonData = JsonConvert.SerializeObject(player);
            StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage  response = await client.DeleteAsync("http://127.0.0.1:8000/api/players/delete/" + player.id);
            string result = await response.Content.ReadAsStringAsync();
            base.OnAppearing();
        }
    }
}
