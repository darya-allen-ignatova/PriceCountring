namespace PriceApp.UI.ViewModels
{
    #region Usings
    using Caliburn.Micro;
    using PriceApp.BusinessLogic;
    using System.Linq;
    #endregion

    public class ProtocolViewModel : Conductor<object>
    {
        private readonly IWindowManager _windowManager;
        private BindableCollection<Provider> _providers = new BindableCollection<Provider>();
        private Provider _selectedProvider;

        public ProtocolViewModel(IWindowManager windowManager)
        {
            _selectedProvider = new Provider();
            _windowManager = windowManager;
        }

        public BindableCollection<Provider> Providers
        {
            get => _providers;
            set
            {
                _providers = value;
                NotifyOfPropertyChange(nameof(Providers));
            }
        }

        public Provider SelectedProvider
        {
            get => _selectedProvider;
            set
            {
                _selectedProvider = value;
                NotifyOfPropertyChange(nameof(SelectedProvider));
            }
        }

        public bool CanSaveCommand => true;

        public void SaveCommand()
        {
            if (SelectedProvider.Id == 0)
            {
                int? lastId = Providers.Where(p => p.Id == Providers.Max(x => x.Id)).FirstOrDefault()?.Id;
                if (lastId != null && lastId != 0)
                {
                    SelectedProvider.Id = (int)lastId++;
                }
                else
                {
                    SelectedProvider.Id = 1;
                }
            }

            Providers.Add(SelectedProvider);
            SelectedProvider = new Provider();
        }

        public void NewCommand()
        {
            SelectedProvider = new Provider();
        }

        public void DeleteCommand()
        {
            Providers.Remove(SelectedProvider);
        }

        public void ConfigurationCommand()
        {
            _windowManager.ShowDialog(new ConfigurationViewModel());
        }
    }
}
