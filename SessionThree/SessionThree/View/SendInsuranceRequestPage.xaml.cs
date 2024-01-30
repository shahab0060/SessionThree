using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Methods;
using SessionThree.Model;
using SessionThree.ViewModel;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionThree.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendInsuranceRequestPage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public SendInsuranceRequestPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
            HospitalsCollectionView.ItemsSource = _context.Hospitals.ToList();
        }

        private async void SendRequestBtn_Clicked(object sender, System.EventArgs e)
        {
            CreateInsuranceRequestViewModel createRequest = new CreateInsuranceRequestViewModel()
            {
                Description = DescriptionInput.Text,
                ImageName = "test.jpg"
            };
            NotificationMethod notificationMethod = new NotificationMethod(_context);
            string message = "";
            if (string.IsNullOrEmpty(createRequest.Description))
            {
                message= "please enter description";
                notificationMethod.AddNotification(message);
                await DisplayAlert("error", message, "cancel");
                return;
            }

            InsuranceRequest insuranceRequest = new InsuranceRequest()
            {
                CreateDate = System.DateTime.Now,
                Description = createRequest.Description,
                ImageName = createRequest.ImageName,
                UserId = AppData.CurrentUserId
            };
            await _context.InsuranceRequests.AddAsync(insuranceRequest);
            await _context.SaveChangesAsync();
            message = "your request has been saved successfully";
            await DisplayAlert("success", message, "ok");
            notificationMethod.AddNotification(message);
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}