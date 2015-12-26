using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PainLogger.UniversalApp.Pages.MedicinePages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MedicineList : Page
    {
        public MedicineList()
        {
            InitializeComponent();
            LoadList();
        }

        public async void LoadList()
        {
            MedicineRepository repository = new MedicineRepository();
            List<Medicine> medicines = await repository.GetAll();
            listView.ItemsSource = medicines;
        }
    }
}