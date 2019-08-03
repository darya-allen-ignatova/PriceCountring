namespace PriceApp.UI.ViewModels
{
    #region Usings
    using Caliburn.Micro;
    using PriceApp.UI.Views;
    #endregion

    public class ProtocolViewModel : Screen
    {
        public ProtocolViewModel()
        {

        }
        public void ConfigurationCommand()
        {
            ConfigurationView sw = new ConfigurationView();
            sw.Show();
        }
    }
}
