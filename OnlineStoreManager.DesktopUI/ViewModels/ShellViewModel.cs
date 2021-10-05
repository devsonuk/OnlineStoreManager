using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.EventModels;
using OnlineStoreManager.DesktopUI.Library.Helpers;
using OnlineStoreManager.DesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<Object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private readonly SalesViewModel _salesVM;
        private readonly ILoggedUserModel _user;
        private readonly IApiHelper _apiHelper;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedUserModel user, IApiHelper apiHelper)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
            _apiHelper = apiHelper;
            _events.SubscribeOnPublishedThread(this);
            _ = ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public bool IsLoggedIn => _user?.AccessToken != null;


        public async Task ExitApplicationAsync()
        {
            await TryCloseAsync();
        }

        public void LogOut()
        {
            _user.Clear();
            _apiHelper.Clear();
            NotifyOfPropertyChange(() => IsLoggedIn);
            _ = ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
