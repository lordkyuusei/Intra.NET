using System;

using Intra.NET.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Intra.NET.Views
{
    public sealed partial class SignPage : Page
    {
        private SignViewModel ViewModel => DataContext as SignViewModel;

        public SignPage()
        {
            InitializeComponent();
        }
    }
}
