using GalaSoft.MvvmLight.Command;
using Products1.Services;
using Products4Grp1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Products4Grp1.Models;
using System.Windows.Input;

namespace Products4Grp1.ViewModel
{
    public class EditCategoryViewModel : INotifyPropertyChanged
    {
    
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        //DataService dataService;
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Attributes
        bool _isRunning;
        bool _isEnabled;
        Category category;
        #endregion

        #region Properties
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public string Description
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public EditCategoryViewModel(Category category)
        {
            this.category = category;

            apiService = new ApiService();
            //dataService = new DataService();
            dialogService = new DialogService();
            navigationService = new NavigationService();

            Description = category.Description;

            IsEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        async void Save()
        {
            if (string.IsNullOrEmpty(Description))
            {
                await dialogService.ShowMessage(
                    "Error",
                    "Debe introducir una descripción de categoría.");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }

            category.Description = Description;
            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.Put(
                "https://products4grp1api100593.azurewebsites.net",
                "/api",
                "/Categories",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken,
                category);

            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    response.Message);
                return;
            }

            var categoriesViewModel = CategoriesViewModel.GetInstance();
            categoriesViewModel.UpdateCategory(category);

            await navigationService.Back();

            IsRunning = false;
            IsEnabled = true;
        }
        #endregion
    }
}
