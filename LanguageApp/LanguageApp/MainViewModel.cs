using LanguageApp.resx;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace LanguageApp
{
    public class MainViewModel : ViewModelBase
    {
        public class LanguagePair
        {
            public Func<string> Name { get; set; }
            public string NameString { get { return Name(); } }
            public string Value { get; set; }
        }
        public List<LanguagePair> languageMapping { get; }
        public LocalizedString CurrentLanguage { get; }
        LanguagePair _selectedLanguage;
        public LanguagePair SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    LocalizationResourceManager.Current.CurrentCulture = value.Value == null ? CultureInfo.CurrentCulture : new CultureInfo(value.Value);
                    OnPropertyChanged();
                }
            }
        }
        public MainViewModel()
        {
            languageMapping = new List<LanguagePair>();
            languageMapping.Add(new LanguagePair { Name = () => AppResources.English, Value = "en" });
            languageMapping.Add(new LanguagePair { Name = () => AppResources.French, Value = "fr" });

            CurrentLanguage = new LocalizedString(() => GetCurrentLanguageName());
            SelectedLanguage = languageMapping.SingleOrDefault(m => m.Value == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
        }
        private string GetCurrentLanguageName()
        {
            string name = languageMapping.SingleOrDefault(m => m.Value == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName).Name();
            return name != null ? name : LocalizationResourceManager.Current.CurrentCulture.DisplayName;
        }
    }
}
