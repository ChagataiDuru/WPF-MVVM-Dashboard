using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using WPF_MVVM_Dashboard.Services;
using WPF_MVVM_Dashboard.ViewModels.WPF_MVVM_Dashboard.ViewModels;

namespace WPF_MVVM_Dashboard.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";

        private readonly IDataService _dataService;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _dateTimeLabel = System.DateTime.Now.ToString();
        public string DateTimeLabel
        {
            get { return _dateTimeLabel; }
            set { SetProperty(ref _dateTimeLabel, value); }
        }

        public DelegateCommand DateTimeUpdateButton { get; }

        private DashboardViewModel _dashboardViewModel;
        public DashboardViewModel DashboardViewModel
        {
            get => _dashboardViewModel;
            set => SetProperty(ref _dashboardViewModel, value);
        }

        public MainWindowViewModel()
        {
            DateTimeUpdateButton = new DelegateCommand(DateTimeUpdateButtonExecute);
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            DashboardViewModel = new DashboardViewModel(_dataService);
        }

        private void DateTimeUpdateButtonExecute()
        {
            DateTimeLabel = DateTime.Now.ToString();
        }
    }
}
