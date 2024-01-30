using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SessionThree.Context;
using SessionThree.Methods;
using SessionThree.Model;
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
    public partial class RegisterPage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public RegisterPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            NotificationMethod notificationMethod = new NotificationMethod(_context);
            RegisterViewModel register = new RegisterViewModel()
            {
                Email = EmailInput.Text,
                FullName = FullNameInput.Text,
                Password = PasswordInput.Text,
                RepeatPassword = RepeatPasswordInput.Text,
                AcceptedRules = AccpetTermsCheckBox.IsChecked
            };
            if (string.IsNullOrEmpty(register.Email) ||
                string.IsNullOrEmpty(register.Password) ||
                string.IsNullOrEmpty(register.RepeatPassword) ||
                string.IsNullOrEmpty(register.FullName))
            {
                string message = "please enter required information";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                 return;
            }
            if(!register.AcceptedRules)
            {
                string message = "you must accept our rules first";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            if(await _context
                .Users.AnyAsync(a=>a.Email.ToLower()==register.Email.ToLower()))
            {
                string message = "a user with this email alrady exists";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            if(register.Password!=register.RepeatPassword)
            {
                string message = "password and repeat pasword are not same";
                notificationMethod.AddNotification(message);
               await DisplayAlert("erro", message, "cancel");
                return;
            }
            Random rnd = new Random();
            SessionThree.Model.User user = new Model.User()
            {
                Email=register.Email,
                Password=register.Password,
                EndDate=DateTime.Now.AddYears(1),
                FullName=register.FullName,
                InsuranceNumber = rnd.Next(100000, 999999),
                StartDate=DateTime.Now
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            AppData.CurrentUserId = user.UserId;
            string message2 = "registered successfully";
            await DisplayAlert("success", message2, "ok");
            notificationMethod.AddNotification(message2);
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}