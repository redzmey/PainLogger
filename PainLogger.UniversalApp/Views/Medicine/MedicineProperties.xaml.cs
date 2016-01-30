using System;
using Windows.UI.Xaml.Controls;
using MyToolkit.UI;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class MedicineProperties : ContentDialog
    {
        private readonly MedicineRepository _repository;

        public MedicineProperties()
        {
            InitializeComponent();
            _repository = new MedicineRepository();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Model.Models.Medicine medicine = new Model.Models.Medicine
            {
                Name = TbxName.Text.Trim(),
                Dosage = Convert.ToDouble(TbxDosage.Text)
            };
            await _repository.AddNew(medicine);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClosePopup();
        }
    }
}