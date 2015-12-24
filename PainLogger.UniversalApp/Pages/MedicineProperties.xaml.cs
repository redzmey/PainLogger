using Windows.UI.Xaml.Controls;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Pages
{
    public sealed partial class MedicineProperties : ContentDialog
    {
      public readonly  MedicineRepository _repository;
        public MedicineProperties()
        {
            this.InitializeComponent();
        _repository = new MedicineRepository();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Medicine medicine = new Medicine()
            {Name = TbxName.Text.Trim()};
            _repository.Create(medicine);

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
