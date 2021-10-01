using Caliburn.Micro;
using OnlineStoreManager.DesktopUI.EventModels;
using OnlineStoreManager.DesktopUI.Library.Helpers;
using System;
using System.Threading.Tasks;

namespace OnlineStoreManager.DesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private readonly IApiHelper _apiHelper;
        private readonly IEventAggregator _events;

        public LoginViewModel(IApiHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }


        public bool CanLogIn => (UserName?.Length > 0 && Password?.Length > 0);


        public bool IsErrorVisible => (ErrorMessage?.Length > 0);

        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var user = await _apiHelper.AuthenticateAsync(UserName, Password);

                // Capture more information about the user
                await _apiHelper.FetchLoggedUser(user.Access_Token);
                await _events.PublishOnUIThreadAsync(new LogOnEvent());

            }
            catch (Exception ex)
            {

                ErrorMessage = $"Invalid UserId or Password({ex.Message})";
            }

        }
    }
}
