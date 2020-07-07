using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Service.Service _service = new Service.Service();
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            var response = await _service.LoginAsync(UserNameEntry.Text, PasswordEntry.Text);
            if (string.IsNullOrEmpty(response))
            {

            }
        }
    }
}