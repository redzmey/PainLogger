using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MyToolkit.Collections;
using MyToolkit.Command;
using MyToolkit.Mvvm;
using PainLogger.Model.Models;
using PainLogger.Model.Repositories;

namespace PainLogger.UniversalApp.ViewModels
{
    public class MedicineViewModel : ViewModelBase
    {
        private string _filter;
        private List<Medicine> _medicines;
        private MedicineRepository _repository;
        private Medicine _selectedMedicine;

        public MtObservableCollection<Medicine> AllElements { get; private set; }

        public ObservableCollectionView<Medicine> FilteredElements { get; private set; }

        public MedicineViewModel()
        {
            DoItCommand = new RelayCommand(DoIt);
            DeleteMedicineAsync = new AsyncRelayCommand<Medicine>(DeleteAsync, medicine=> medicine != null);

            AllElements = new MtObservableCollection<Medicine>();
            FilteredElements = new ObservableCollectionView<Medicine>(AllElements);
        }

        public AsyncRelayCommand<Medicine> DeleteMedicineAsync { get; private set; }
        public RelayCommand DoItCommand { get; private set; }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (Set(ref _filter, value))
                {
                    FilteredElements.Filter = entry =>
                        string.IsNullOrEmpty(_filter) ||
                        entry.Name.Contains(_filter);
                }
            }
        }

        public Medicine SelectedMedicine
        {
            get { return _selectedMedicine; }
            set { Set(ref _selectedMedicine, value); }
        }

        private async Task DeleteAsync(Medicine medicine)
        {
            await _repository.Delete(medicine);
            AllElements.Initialize(_repository.GetAll().Result);
        }

        private void DoIt()
        {
            var a = "aaaa";
        }

        public override void Initialize()
        {
            base.Initialize();
            _repository = new MedicineRepository();
            AllElements.Initialize(_repository.GetAll().Result);
        }
    }
}