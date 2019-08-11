namespace PriceApp.UI.ViewModels
{
    #region Usings
    using System.Globalization;
    using System.Windows;
    using Caliburn.Micro;
    using PriceApp.BusinessLogic.FileService;
    using PriceApp.BusinessLogic.Models;
    using PriceApp.UI.Configuration;
    #endregion

    public class ConfigurationViewModel : Screen
    {
        private ConfigurationSettings _configurationSettings;
        private BindableCollection<CultureInfo> _cultures = new BindableCollection<CultureInfo>();
        
        public ConfigurationViewModel()
        {
            _configurationSettings = ConfigurationFileHelper.ReadFromFileConfigurationSettings();
            _cultures.AddRange(LocalizationSettings.Cultures);
            SelectedCulture = LocalizationSettings.Culture;
        }

        public ConfigurationSettings ConfigurationSettings
        {
            get => _configurationSettings;
            set
            {
                _configurationSettings = value;
                NotifyOfPropertyChange(nameof(ConfigurationSettings));
            }
        }

        public CultureInfo SelectedCulture
        {
            get => _configurationSettings.Culture;
            set
            {
                _configurationSettings.Culture = value;
                NotifyOfPropertyChange(nameof(SelectedCulture));
            }
        }

        public BindableCollection<CultureInfo> Cultures
        {
            get => _cultures;
            set => _cultures = value;
        }

        public void SaveSettingsCommand()
        {
            LocalizationSettings.Culture = ConfigurationSettings.Culture;
            ConfigurationFileHelper.WriteConfigurationSettings(ConfigurationSettings);

            //TODO: insert into resources
            MessageBox.Show("Сохранено", "Конфигурация языковой культуры");
        }
    }
}
