using System;
using Windows.UI.Xaml.Controls;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class MedicineProperties : ContentDialog
    {
        public readonly MedicineRepository _repository;

        public MedicineProperties()
        {
            InitializeComponent();
            _repository = new MedicineRepository();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Model.Models.Medicine medicine = new Model.Models.Medicine {Name = TbxName.Text.Trim(), Dosage = Convert.ToDouble(TbxDosage.Text) };
            _repository.AddNew(medicine);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}