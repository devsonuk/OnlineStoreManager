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
        private readonly SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM, SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;
            _events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM);
        }
    }
}
