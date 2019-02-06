using Products4Grp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Products4Grp1.ViewModel
{
    public class CategoriesViewModel
    {
        #region Properties
        public ObservableCollection<Category> Categories
        {
            get;
            set;
            //get
            //{
            //    return _categories;
            //}
            //set
            //{
            //    if (_categories != value)
            //    {
            //        _categories = value;
            //        PropertyChanged?.Invoke(
            //            this,
            //            new PropertyChangedEventArgs(nameof(Categories)));
            //    }
            //}
        }
        #endregion

        #region Constructors
        public CategoriesViewModel()
        {
            //instance = this;

            //apiService = new ApiService();
            //dataService = new DataService();
            //dialogService = new DialogService();

            LoadCategories();
        }
        #endregion

        #region Methods
        void LoadCategories()
        {

        }
        #endregion
    }
}
