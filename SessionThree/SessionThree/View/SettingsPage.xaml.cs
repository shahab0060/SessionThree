using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Methods;
using SessionThree.Model;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionThree.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : TabbedPage
    {
        private readonly InsuranceDbContext _context;
        public SettingsPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            Model.User user = await _context.Users.FirstOrDefaultAsync(a=>a.UserId==AppData.CurrentUserId);
            BindingContext = user;
            base.OnAppearing();
        }

        private async void ChangePasswordBtn_Clicked(object sender, System.EventArgs e)
        {
            string currentPassword = CurrentPasswordInput.Text;
            string newPassword = NewPasswordInput.Text;
            string repeatNewPassword = RepeatNewPasswordInput.Text;
            
            NotificationMethod notificationMethod = new NotificationMethod(_context);
            string message = "";
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(repeatNewPassword))
            {
                message = "please enter all of the inputs first";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            Model.User user = await _context.Users
                .FirstOrDefaultAsync(a => a.UserId == AppData.CurrentUserId && a.Password == currentPassword);
            if (user==null || user.UserId==0)
            {
                message = " please enter information correctly in the change password form";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            if(newPassword==currentPassword)
            {
                message = "new password can not be current password";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            if(newPassword!=repeatNewPassword)
            {
                message = "new password and repeat new password are not same";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            user.Password = newPassword;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            message = "your password has been saved successfully";
            await DisplayAlert("success", message, "ok");
            notificationMethod.AddNotification(message);
        }

        private async void SaveGeneralInformationBtn_Clicked(object sender, System.EventArgs e)
        {
            string fullName = FullNameInput.Text;
            string email = EmailInput.Text;
            string message = "";
            NotificationMethod notificationMethod =  new NotificationMethod(_context);
            if(string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                message = "please enter all the required fields first";
                await DisplayAlert("error", message, "cancel");
                notificationMethod.AddNotification(message);
                return;
            }
            Model.User user = await _context
                .Users.FirstOrDefaultAsync(a => a.UserId == AppData.CurrentUserId);
            user.FullName = fullName;
            user.Email = email;
            _context.Users.Attach(user);
            await _context.SaveChangesAsync(true);
            message = "your general information has been saved successfully";
            await DisplayAlert("success", message, "ok");
            notificationMethod.AddNotification(message);
        }
    }
}