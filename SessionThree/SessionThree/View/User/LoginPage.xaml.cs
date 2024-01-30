using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Methods;
using SessionThree.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionThree.View.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public LoginPage() 
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            LoginViewModel login = new LoginViewModel() {
                Email = EmailInput.Text,
                Password = PasswordInput.Text,
            };
            NotificationMethod notificationMethod = new NotificationMethod(_context);
            if(string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                string message = "please enter username and password";
                await DisplayAlert("alert", message,"cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            long userId = await _context.Users.Where(a => a.Email == login.Email && a.Password == login.Password)
                .Select(a=>a.UserId)
                .FirstOrDefaultAsync();
            if (!(userId > 0))
            {
                string message = "incorrect username or password";
                await DisplayAlert("alert", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            AppData.CurrentUserId = userId;
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}