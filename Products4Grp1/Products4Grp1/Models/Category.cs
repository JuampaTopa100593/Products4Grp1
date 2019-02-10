using GalaSoft.MvvmLight.Command;
using Products4Grp1.ViewModel;
using Products4Grp1.Services;
using System.Collections.Generic;
using System.Windows.Input;

namespace Products4Grp1.Models
{
    public class Category
    {
        #region Services
        //DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Constructors
        public Category()
        {
            //dialogService = new DialogService();
            navigationService = new NavigationService();
        }
        #endregion

        #region Properties
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
        #endregion

        #region Commands
        public ICommand SelectCategoryCommand
        {
            get
            {
                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Products = new ProductsViewModel(Products);
            await navigationService.Navigate("ProductsView");
            
        }
        #endregion
    }
}
