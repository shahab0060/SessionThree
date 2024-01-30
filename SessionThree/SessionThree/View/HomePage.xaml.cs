using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionThree.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public HomePage()
        {
            InitializeComponent();
            _context = new InsuranceDbContext();
            SetUserInfo();
        }

        void SetUserInfo()
        {
            BindingContext = _context.Users.FirstOrDefault(a => a.UserId == AppData.CurrentUserId);
        }

        private async void SearchDoctorsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchDoctorsPage());
        }

        private async void SearchHospitalsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SearchHospitalsPage());
        }

        private async void SendInsuranceRequestBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SendInsuranceRequestPage());
        }

        private async void ViewNotificationsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NotificationsPage());
        }

        private async void ViewSettingsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }
    }
}