using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF_MVVM_Dashboard.Helpers;


namespace WPF_MVVM_Dashboard.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using Microsoft.Win32;
    using Prism.Mvvm;
    using Prism.Commands;
    using global::WPF_MVVM_Dashboard.Services;

namespace WPF_MVVM_Dashboard.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        private readonly IDataService _dataService;

        private ObservableCollection<PlayerStats> _playerStats;
        public ObservableCollection<PlayerStats> PlayerStats
        {
            get => _playerStats;
            set => SetProperty(ref _playerStats, value);
        }

        private string _selectedCsvFilePath;
        public string SelectedCsvFilePath
        {
            get => _selectedCsvFilePath;
            set
            {
                SetProperty(ref _selectedCsvFilePath, value);
                LoadData();
            }
        }

        public DelegateCommand LoadDataCommand { get; private set; }
        public DelegateCommand SelectCsvFileCommand { get; private set; }

        public DashboardViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadDataCommand = new DelegateCommand(LoadData);
            SelectCsvFileCommand = new DelegateCommand(SelectCsvFile);
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(SelectedCsvFilePath))
            {
                PlayerStats = new ObservableCollection<PlayerStats>(_dataService.GetPlayerStats(SelectedCsvFilePath));
            }
        }

        private void SelectCsvFile()
        {
            var dialog = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            if (dialog.ShowDialog() == true)
            {
                SelectedCsvFilePath = dialog.FileName;
            }
        }
    }
}

}