using System;
using System.Collections.Generic;
using System.Windows.Input;
using Intra.NET.Constants;
using Intra.NET.Helpers;
using Intra.NET.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace Intra.NET.ViewModels
{
    public class DashViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private HttpClientWrapper clientWrapper;
        private EpitechStudent epitechStudent;
        private string dashboard;

        internal string Dashboard
        {
            get => dashboard;
            set => SetProperty(ref dashboard, value);
        }

        public ICommand IsUserSignedInCommand { get; set; }
        public int EctsRatio
        {
            get => (epitechStudent.CurrentCredits / 60) * 100;
        }

        public int EctsValue
        {
            get => epitechStudent.CurrentCredits;
        }

        public DashViewModel(INavigationService navigationService)
        {
            clientWrapper = HttpClientWrapper.Instance;
            epitechStudent = EpitechStudent.Instance;
            this.navigationService = navigationService;

            IsUserSignedInCommand = new DelegateCommand(IsUserSignedIn);
        }

        public void IsUserSignedIn()
        {
            if (clientWrapper.GetCookieFrom(new Uri(EntAPI.intranetUri)) != null)
            {
                LoadDashBoard();
            }
            else
                navigationService.Navigate("Sign", null);
        }

        internal async void LoadDashBoard()
        {
            Dashboard = await clientWrapper.GetStringAsync(new Uri(EntAPI.intranetUri));
        }
    }
}
