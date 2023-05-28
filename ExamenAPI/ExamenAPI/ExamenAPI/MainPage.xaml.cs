using ExamenAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExamenAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private string Url = "https://pokeapi.co/api/v2";
        private Models.User Users { get; set; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var json = wc.DownloadString(Url + "/users/" + txtId.Text);
                var user = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.User>(json);

                if (user != null)
                {
                    txtId.Text = user.Id.ToString();
                    txtNombre.Text = user.FirstName;
                    txtApellido.Text = user.LastName;
                    txtEmail.Text = user.Email;
                    txtAvatar.Text = user.Avatar;
                }
                else
                {
                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtAvatar.Text = "";
                }

            }


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {

        }
    }
}
