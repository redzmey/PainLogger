using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using MyToolkit.Paging;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;
using PainLogger.UniversalApp.ViewModels;

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class PainListPage
    {
        public PainListPage()
        {
            InitializeComponent();
            //Model.PropertyChanged += (sender, args) =>
            //{
            //    if (args.IsProperty<DataGridPageModel>(m => m.Filter))
            //    {
            //        DataGrid.SetFilter<Person>(p =>
            //            p.FirstName.ToLower().Contains(Model.Filter.ToLower()) ||
            //            p.LastName.ToLower().Contains(Model.Filter.ToLower()) ||
            //            p.Category.ToLower().Contains(Model.Filter.ToLower()));
            //    }
            //};
            LoadList();
        }

        public DataGridPageModel Model => (DataGridPageModel) Resources["ViewModel"];

        private async void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            PainPropertiesPage painPropertiesPage = new PainPropertiesPage();
            await painPropertiesPage.ShowAsync();
            LoadList();
        }

        public async void LoadList()
        {
            try
            {
                PainRecordRepository repository = new PainRecordRepository();
                List<PainRecord> painRecords = await repository.GetAll();

                listView.ItemsSource = painRecords;
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnLoadState(MtLoadStateEventArgs pageState)
        {
            Model.Filter = pageState.Get<string>("Filter");
        }

        protected override void OnSaveState(MtSaveStateEventArgs pageState)
        {
            pageState.Set("Filter", Model.Filter);
        }
    }
}