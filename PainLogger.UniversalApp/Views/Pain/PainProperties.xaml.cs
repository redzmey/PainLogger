using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class PainProperties : ContentDialog
    {
        public readonly PainRecordRepository _repository;

        public PainProperties()
        {
            InitializeComponent();
            _repository = new PainRecordRepository();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            BloodPressureAndHeartRate bloodPressure = new BloodPressureAndHeartRate {HeartRate = 110, HighPressure = 120, LowerPressure = 80, TakenTime = DateTime.Now};
            List<BloodPressureAndHeartRate> measures = new List<BloodPressureAndHeartRate> {bloodPressure};
            PainRecord newPainRecord = new PainRecord {Level = 1, TakenTime = DateTime.Now, Measures = measures};
            _repository.AddNew(newPainRecord);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}