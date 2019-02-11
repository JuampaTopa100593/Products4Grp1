using GalaSoft.MvvmLight.Command;
using Products4Grp1.Models;
using System;
using System.Windows.Input;
using Products4Grp1.Services;

namespace Products4Grp1.ViewModel
{
    public class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region properties
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;
        }
        public ProductsViewModel Products
        {
            get;
            set;
        }
        public NewCaterogyViewModel NewCaterogy {
            get;
            set;
        }

        public EditCategoryViewModel EditCategory
        {
            get;
            set;
        }
        #endregion

        #region Costructors
        public MainViewModel()
        {
            instance = this;
            navigationService = new NavigationService();
            Login = new LoginViewModel();
        }
        #endregion

        #region Commands
        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(GoNewCategory);
            }
        }

        async void GoNewCategory()
        {
            NewCaterogy = new NewCaterogyViewModel();
            await navigationService.Navigate("NewCategoryView");
        }
        #endregion

        #region Singelton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
