using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.Helpers;
using OnlineStoreManager.DesktopUI.Library.Helpers;
using OnlineStoreManager.DesktopUI.Library.Models;
using OnlineStoreManager.DesktopUI.Library.Services;
using OnlineStoreManager.DesktopUI.Library.Services.Interfaces;
using OnlineStoreManager.DesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStoreManager.DesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(PasswordBoxHelper.BoundPasswordProperty, "Password", "PasswordChanged");
        }

        protected override void Configure()
        {
            _ = _container.Instance(_container)
                .PerRequest<IProductService, ProductService>();

            _ = _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedUserModel, LoggedUserModel>()
                .Singleton<IConfigHelper,ConfigHelper>()
                .Singleton<IApiHelper, ApiHelper>();


            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(classType => classType.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
