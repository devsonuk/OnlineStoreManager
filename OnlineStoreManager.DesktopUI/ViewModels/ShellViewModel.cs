using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.EventModels;
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
        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;
            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM);
        }
    }
}
