﻿namespace PenilaianAndroidApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new PenilaianAndroidApp.App());
        }
    }
}