namespace PriceApp.UI
{
    #region Usings
    using System.Windows;
    using Caliburn.Micro;
    using PriceApp.UI.ProtocolDetails;
    #endregion
    
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ProtocolViewModel>();
        }
    }
}
