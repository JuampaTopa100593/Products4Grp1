﻿namespace Products4Grp1.Droid.Infrastructure
{
    using ViewModel;
    public class InstanceLocator
    {
        public MainViewModel Main
        {
            get;
            set;
        }
        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}