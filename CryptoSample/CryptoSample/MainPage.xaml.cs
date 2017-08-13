using CryptoSampleAPI.Models;
using Newtonsoft.Json;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CryptoSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

      

        private async void nameLogin_Clicked(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel() { UserName = nameUserName.Text, Password = namePassword.Text };
            var stringToEncrypt = JsonConvert.SerializeObject(loginModel);
            var stringToSend = Crypto.Encrypt(stringToEncrypt);

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://cryptosampleapi.azurewebsites.net/api/login?loginInfo="+ stringToSend);
            var content = new StringContent("", Encoding.UTF8);
            HttpResponseMessage response = await client.PostAsync("", content);
            var result = await response.Content.ReadAsStringAsync();
            lblResult.Text = result;
        }
    }
}
