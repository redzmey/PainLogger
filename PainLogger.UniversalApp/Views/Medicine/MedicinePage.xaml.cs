using System;
using Windows.UI.Xaml;
using MyToolkit.Paging;
using PainLogger.UniversalApp.ViewModels;

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class MedicinePage
    {
        public MedicinePage()
        {
            InitializeComponent();
            RegisterViewModel(Model);
        }

        public MedicineViewModel Model => (MedicineViewModel) Resources["ViewModel"];

        private async void BtnAddNew_Click(object sender, RoutedEventArgs e)
        {
            MedicineProperties medicineProperties = new MedicineProperties();
            await medicineProperties.ShowAsync();
        }

        protected override void OnLoadState(MtLoadStateEventArgs pageState)
        {
            Model.Filter = pageState.Get<string>("Filter");
        }

        protected override void OnSaveState(MtSaveStateEventArgs pageState)
        {
            pageState.Set("Filter", Model.Filter);
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}