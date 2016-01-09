using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using MyToolkit.UI;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Views
{
    public sealed partial class PainPropertiesPage : ContentDialog
    {
        public readonly PainRecordRepository _repository;

        public PainPropertiesPage()
        {
            InitializeComponent();
            _repository = new PainRecordRepository();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            DateTime started = new DateTime(StartDate.Date.Year, StartDate.Date.Month, StartDate.Date.Day, StartTime.Time.Hours, StartTime.Time.Minutes, StartTime.Time.Seconds);
            int level = Convert.ToInt32(TbxLevel.Text);
            BloodPressureAndHeartRate bloodPressure = new BloodPressureAndHeartRate {HeartRate = 110, HighPressure = 120, LowerPressure = 80, TakenTime = started };
            List<BloodPressureAndHeartRate> measures = new List<BloodPressureAndHeartRate> {bloodPressure};
            PainRecord newPainRecord = new PainRecord {Level = level, TakenTime = started, Measures = measures};
            _repository.AddNew(newPainRecord);
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClosePopup();
        }
    }
}