namespace PriceApp.UI
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Caliburn.Micro;
    using PriceApp.UI.ViewModels;
    #endregion

    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();
            _container.PerRequest<IWindowManager, WindowManager>();
            _container.PerRequest<IEventAggregator, EventAggregator>();
            _container.PerRequest<ProtocolViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ProtocolViewModel>();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
