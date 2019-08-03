namespace PriceApp.UI.ViewModels
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

    public class ConfigurationViewModel : Screen
    {
        private CultureInfo _selectedCulture;
        private BindableCollection<CultureInfo> _cultures = new BindableCollection<CultureInfo>();
        
        public ConfigurationViewModel()
        {
            Cultures.AddRange(LocalizationSettings.Cultures);
            SelectedCulture = LocalizationSettings.Culture;
        }

        public CultureInfo SelectedCulture
        {
            get => _selectedCulture;
            set
            {
                _selectedCulture = value;
                NotifyOfPropertyChange(nameof(SelectedCulture));
            }
        }

        public BindableCollection<CultureInfo> Cultures
        {
            get => _cultures;
            set => _cultures = value;
        }


        public void SaveSettings()
        {
            LocalizationSettings.Culture = SelectedCulture;
            //TODO: insert into resources
            MessageBox.Show("Сохранено");
        }

    }
}
