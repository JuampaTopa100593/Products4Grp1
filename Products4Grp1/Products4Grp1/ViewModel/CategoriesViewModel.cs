using Products1.Services;
using Products4Grp1.Models;
using Products4Grp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Products4Grp1.ViewModel
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        #endregion

        #region Attributes
        //List<Category> categories;
        ObservableCollection<Category> _categories;
        //bool _isRefreshing;
        //string _filter;
        #endregion

        #region Properties
        public ObservableCollection<Category> CategoriesList
        {
            get
            {
                return _categories;
            }
            set
            {
                if (_categories != value)
                {
                    _categories = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(CategoriesList)));
                }
            }
        }
        #endregion

        #region Constructors
        public CategoriesViewModel()
        {
            //instance = this;

            apiService = new ApiService();
            //dataService = new DataService();
            dialogService = new DialogService();

            LoadCategories();
        }
        #endregion

        #region Methods
        async void LoadCategories()
        {
            //IsRefreshing = true;
            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                 await dialogService.ShowMessage(
                    "Error",
                 connection.Message); ///sufrio cambio del original
                 return;
            }

            var mainViewModel = MainViewModel.GetInstance();

            var response = await apiService.GetList<Category>("https://products4grp1api100593.azurewebsites.net",
                "/api", "/Categories", mainViewModel.Token.TokenType, mainViewModel.Token.AccessToken);
            if(!response.IsSuccess)
            {
                await dialogService.ShowMessage(
                    "Error",
                 response.Message); ///sufrio cambio del original
                return;
            }
            
            var categories = (List<Category>)response.Result;
            CategoriesList = new ObservableCollection<Category>(
                categories.OrderBy(c => c.Description));
        }
        #endregion
    }
}
