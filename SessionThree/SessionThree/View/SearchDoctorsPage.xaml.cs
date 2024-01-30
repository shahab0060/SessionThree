using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Model;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SessionThree.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchDoctorsPage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public SearchDoctorsPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
        }

        private void CallDoctorBtn_Clicked(object sender, System.EventArgs e)
        {

        }

        private async void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = e.NewTextValue;
            value = value.Trim();
            DoctorsListView.IsRefreshing = true;
            DoctorsListView.ItemsSource = await _context
                .Doctors
                .Where(a => EF.Functions.Like(a.Address, $"%{value}%") ||
                          EF.Functions.Like(a.FullName, $"%{value}%") ||
                          EF.Functions.Like(a.Major, $"%{value}%"))
                .ToListAsync();
            DoctorsListView.IsRefreshing = false;
        }
    }
}