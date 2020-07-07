using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApp.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebApiApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        Service.Service Service = new Service.Service();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (((string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) ||
                (string.IsNullOrWhiteSpace(phonenumberEntry.Text)) ||
                (string.IsNullOrWhiteSpace(emailEntry.Text)) ||
                (string.IsNullOrWhiteSpace(passwordEntry.Text)) ||
                (string.IsNullOrWhiteSpace(phonenumberEntry.Text))))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
            }
            else if (phonenumberEntry.Text.Length < 10)
            {
                phonenumberEntry.Text = string.Empty;
                await DisplayAlert("Alert", "Phone Number is empty", "OK");
            }
            else
            {
                try
                {
                    bool response = await Service.RegisterAsync(emailEntry.Text, passwordEntry.Text, usernameEntry.Text, phonenumberEntry.Text);

                    if (response)
                    {
                        await DisplayAlert("Alert", "Registration Successful", "OK");
                        await Navigation.PushModalAsync(new LoginPage());
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Email or Username is already exist, try different one", "OK");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}