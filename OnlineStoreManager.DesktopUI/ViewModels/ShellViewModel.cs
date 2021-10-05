using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.EventModels;
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
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, ILoggedUserModel user)
        {
            _events = events;
            _salesVM = salesVM;
            _user = user;
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
            _user.Reset();
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
