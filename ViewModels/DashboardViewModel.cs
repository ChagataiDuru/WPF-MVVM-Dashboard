using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF_MVVM_Dashboard.Helpers;


namespace WPF_MVVM_Dashboard.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PlayerStats> _playerStats;
        public ObservableCollection<PlayerStats> PlayerStats
        {
            get => _playerStats;
            set
            {
                _playerStats = value;
                OnPropertyChanged(nameof(PlayerStats));
            }
        }

        public ICommand LoadDataCommand { get; set; }

        public DashboardViewModel()
        {
            LoadDataCommand = new RelayCommand(LoadData);
            PlayerStats = new ObservableCollection<PlayerStats>();
        }

        private void LoadData()
        {
            // TODO: Implement data loading logic
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}