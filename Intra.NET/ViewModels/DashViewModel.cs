using System;
using System.Collections.Generic;
using System.Windows.Input;
using Intra.NET.Constants;
using Intra.NET.Helpers;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace Intra.NET.ViewModels
{
    public class DashViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private HttpClientWrapper clientWrapper;
        public ICommand isUserSignedInCommand;

        private string dashboard;
        public string Dashboard
        {
            get => dashboard;
            set => SetProperty(ref dashboard, value);
        }

        public DashViewModel(INavigationService navigationService)
        {
            clientWrapper = HttpClientWrapper.Instance;
            this.navigationService = navigationService;
            isUserSignedInCommand = new DelegateCommand(IsUserSignedIn);

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

        public async void LoadDashBoard()
        {
            Dashboard = await clientWrapper.GetStringAsync(new Uri(EntAPI.intranetUri));
        }
    }
}
