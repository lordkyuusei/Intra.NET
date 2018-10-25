using System;

using Intra.NET.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Intra.NET.Views
{
    public sealed partial class DashPage : Page
    {
        private DashViewModel ViewModel => DataContext as DashViewModel;

        public DashPage()
        {
            InitializeComponent();
        }
    }
}
