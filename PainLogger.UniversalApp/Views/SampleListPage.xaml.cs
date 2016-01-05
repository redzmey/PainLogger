using System;
using System.Collections.Generic;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class SampleListPage
    {
        public SampleListPage()
        {
            InitializeComponent();
            LoadList();
        }

        private async void BtnAddNew_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MedicineProperties medicineProperties = new MedicineProperties();
            await medicineProperties.ShowAsync();
        }

        public async void LoadList()
        {
            try
            {
                MedicineRepository repository = new MedicineRepository();
                List<Medicine> medicines = await repository.GetAll();

                listView.ItemsSource = medicines;
            }
            catch (Exception ex)
            {
            }
        }
    }
}