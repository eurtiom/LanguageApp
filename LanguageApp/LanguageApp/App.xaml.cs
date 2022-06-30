using LanguageApp.resx;
using System;
using System.Globalization;
using System.Threading;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*CultureInfo ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            AppResources.Culture = ci;

            AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;*/
            LocalizationResourceManager.Current.PropertyChanged += Current_PropertyChanged;
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);


            /*
            CultureInfo info = new CultureInfo("fr");
            Thread.CurrentThread.CurrentUICulture = info;
            AppResources.Culture = info;*/

            MainPage = new MainPage();
        }
        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            AppResources.Culture = LocalizationResourceManager.Current.CurrentCulture;
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
