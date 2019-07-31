namespace PriceApp.UI.Settings
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using Caliburn.Micro;
    using PriceApp.UI.Configuration;
    #endregion

    public class SettingsViewModel : Screen
    {
        private string _selectedCulture;
        public List<string> Cultures => LocalizationSettings.Cultures.Select(x => x.DisplayName).ToList();

        public string SelectedCulture
        {
            get => _selectedCulture;
            set
            {
                _selectedCulture = value;
                NotifyOfPropertyChange(nameof(SelectedCulture));
            }
        }

        public SettingsViewModel()
        {
            CultureInfo currentCulture = LocalizationSettings.Culture;

            
        }

        private void LanguageChanged()
        {
            CultureInfo currLang = LocalizationSettings.Language;

            
        }

        public void SaveSettings()
        {
          
        }

    }
}
