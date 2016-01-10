using System;
using Windows.UI.Xaml.Controls;
using MyToolkit.UI;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class MedicationProperties : ContentDialog
    {
        public readonly MedicationRepository _repository;

        public MedicationProperties()
        {
            InitializeComponent();
            _repository = new MedicationRepository();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Model.Models.Medication medication = new Model.Models.Medication {DosageCount = 1, TakenTime = DateTime.Now};
            _repository.AddNew(medication);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClosePopup();
        }
    }
}