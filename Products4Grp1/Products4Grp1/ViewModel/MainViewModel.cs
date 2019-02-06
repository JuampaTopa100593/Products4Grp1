namespace Products4Grp1.ViewModel
{
    public class MainViewModel
    {
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
        #endregion

        #region Costructors
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
        #endregion
    }
}
