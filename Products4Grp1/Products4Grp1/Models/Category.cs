using GalaSoft.MvvmLight.Command;
using Products4Grp1.ViewModel;
using Products4Grp1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Products4Grp1.Models
{
    public class Category
    {
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
            await Application.Current.MainPage.Navigation.PushAsync(
                new ProductsView());
        }
        #endregion
    }
}
