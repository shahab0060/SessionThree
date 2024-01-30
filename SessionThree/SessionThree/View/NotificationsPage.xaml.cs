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
    public partial class NotificationsPage : ContentPage    
    {
        private readonly InsuranceDbContext _context;
        public NotificationsPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            NotificationsListView.IsRefreshing = true;
            NotificationsListView.ItemsSource = await _context.Notifications
                .Where(a=>a.UserId==AppData.CurrentUserId)
                .ToListAsync();
            NotificationsListView.IsRefreshing = false;
            base.OnAppearing();
        }
    }
}