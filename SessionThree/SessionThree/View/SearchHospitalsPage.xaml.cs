using Microsoft.EntityFrameworkCore;
using SessionThree.Context;
using SessionThree.Model;
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
    public partial class SearchHospitalsPage : ContentPage
    {
        private readonly InsuranceDbContext _context;
        public SearchHospitalsPage()
        {
            _context = new InsuranceDbContext();
            InitializeComponent();
        }

        private void DoctorsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void SearchInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = e.NewTextValue;
            value = value.Trim();
            HospitalsListView.IsRefreshing = true;
            HospitalsListView.ItemsSource= await _context
                .Hospitals
                .Where(a => EF.Functions.Like(a.Type, $"%{value}%") ||
                          EF.Functions.Like(a.Title, $"%{value}%"))
                .ToListAsync();
            HospitalsListView.IsRefreshing = false;
        }
    }
}