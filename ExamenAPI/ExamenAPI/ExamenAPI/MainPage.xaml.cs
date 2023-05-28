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
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using ExamenAPI.Models;
namespace ExamenAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private string Url = "https://jsonplaceholder.typicode.com/posts";
        private Models.Post Users { get; set; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                Console.WriteLine("...."+txtId.Text);
                var json = wc.DownloadString(Url + "/" + txtId.Text);
                var posts = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Post>(json);
                if (posts != null)
                {
                    txtId.Text = posts.id;
                    txtuserId.Text = posts.userId.ToString();
                    txtTittle.Text = posts.title;
                    txtBody.Text = posts.body;
                }
                else
                {
                    txtId.Text = "";
                    txtuserId.Text = "";
                    txtTittle.Text = "";
                    txtBody.Text = "";
                }
            }


        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Post
                {
                    id = txtId.Text,
                    userId = 1,
                    title = txtTittle.Text,
                    body = txtBody.Text,
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Url, "POST", json);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Post
                {
                    id = txtId.Text,
                    userId = 1,
                    title = txtTittle.Text,
                    body = txtBody.Text,
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
                txtuserId.Text = "";
                txtTittle.Text = "";
                txtBody.Text = "";
            }
        }
    }
}
