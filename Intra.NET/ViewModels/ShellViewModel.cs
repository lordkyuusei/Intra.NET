﻿using System;
using System.Linq;
using System.Windows.Input;

using Intra.NET.Helpers;

using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Intra.NET.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private NavigationView _navigationView;
        private NavigationViewItem _selected;
        private bool isPaneOpen = false;
        public bool IsPaneOpen
        {
            get => isPaneOpen;
            set => SetProperty(ref isPaneOpen, value);
        }

        public ICommand ItemInvokedCommand { get; }

        public NavigationViewItem Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ShellViewModel(INavigationService navigationServiceInstance)
        {
            _navigationService = navigationServiceInstance;
            ItemInvokedCommand = new DelegateCommand<NavigationViewItemInvokedEventArgs>(OnItemInvoked);
        }

        public void Initialize(Frame frame, NavigationView navigationView)
        {
            _navigationView = navigationView;
            frame.Navigated += Frame_Navigated;
        }

        private void OnItemInvoked(NavigationViewItemInvokedEventArgs args)
        {
            var item = _navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .First(menuItem => (string)menuItem.Content == (string)args.InvokedItem);
            var pageKey = item.GetValue(NavHelper.NavigateToProperty) as string;
            isPaneOpen = false;
            _navigationService.Navigate(pageKey, null);
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            Selected = _navigationView.MenuItems
                            .OfType<NavigationViewItem>()
                            .FirstOrDefault(menuItem => IsMenuItemForPageType(menuItem, e.SourcePageType));
        }

        private bool IsMenuItemForPageType(NavigationViewItem menuItem, Type sourcePageType)
        {
            var sourcePageKey = sourcePageType.Name;
            sourcePageKey = sourcePageKey.Substring(0, sourcePageKey.Length - 4);
            var pageKey = menuItem.GetValue(NavHelper.NavigateToProperty) as string;
            return pageKey == sourcePageKey;
        }
    }
}
