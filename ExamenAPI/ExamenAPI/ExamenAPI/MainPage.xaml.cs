using ExamenAPI.Models;
using Octokit.Internal;
using Refit;
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
        private string Url = "https://reqres.in/api";
        private Models.User Users { get; set; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(txtId.Text, out userId))
            {
                using (var wc = new WebClient())
                {
                    var url = $"{Url + "/users/" + txtId.Text}"; // Construir la URL completa
                    wc.Headers.Add("Content-Type", "application/json");
                    var json = wc.DownloadString(url);
                    var response = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);

                    if (response != null)
                    {
                        txtId.Text = response.Id.ToString();
                        txtNombre.Text = response.FirstName;
                        txtApellido.Text = response.LastName;
                        txtEmail.Text = response.Email;
                        txtAvatar.Text = response.Avatar;
                    }
                    {
                        txtId.Text = "";
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtEmail.Text = "";
                        txtAvatar.Text = "";
                    }
                }
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

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.User
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtNombre.Text,
                    LastName = txtApellido.Text,
                    Email = txtEmail.Text,
                    Avatar = txtAvatar.Text,
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Url, "POST", json);
                lblDatos.Text = "DATOS INSERTADOS CON EXITO";
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.User
                {
                    Id = int.Parse(txtId.Text),
                    FirstName = txtNombre.Text,
                    LastName = txtApellido.Text,
                    Email = txtEmail.Text,
                    Avatar = txtAvatar.Text,
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Url + "/" + txtId.Text, "PUT", json);
                lblDatos.Text = "DATOS ACTUALIZADOS CON EXITO";
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                wc.UploadString(Url + "/" + txtId.Text, "DELETE", "");
                lblDatos.Text = "DATOS Borrados CON EXITO";
                txtId.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtAvatar.Text = "";
            }
        }
    }
}
