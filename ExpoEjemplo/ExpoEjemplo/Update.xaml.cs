using ExpoEjemplo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpoEjemplo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        public Update(Player player)
        {
            InitializeComponent();

            id.Text = player.id.ToString();
            Nombre.Text = player.name;
            Apellidos.Text = player.lastname;
            Email.Text = player.email;
            Telefono.Text = player.phone;
            Nickname.Text = player.nickname;
            Videojuego.Text = player.game;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}