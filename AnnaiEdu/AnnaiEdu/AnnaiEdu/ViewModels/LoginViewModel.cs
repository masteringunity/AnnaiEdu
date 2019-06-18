using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaiEdu.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "ReactiveUI with Xamarin!";
        public IScreen HostScreen { get; protected set; }

        string _userName;
        public string Username
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        public ReactiveCommand LoginCommand { get; set; }


        ObservableAsPropertyHelper<bool> _isLoading;
        public bool IsLoading
        {
            get { return _isLoading?.Value ?? false; }
        }


        ObservableAsPropertyHelper<bool> _isValid;
        public bool IsValid
        {
            get { return _isValid?.Value ?? false; }
        }

        public LoginViewModel()
        {
            HostScreen = Locator.Current.GetService<IScreen>();
            PrepareObservables();
        }

        private void PrepareObservables()
        {

            this.WhenAnyValue(e => e.Username, p => p.Password,
              (emailAddress, password) => (!string.IsNullOrEmpty(emailAddress)) && !string.IsNullOrEmpty(password) && password.Length > 6)
          .ToProperty(this, v => v.IsValid, out _isValid);

            var canExecuteLogin =
            this.WhenAnyValue(x => x.IsLoading, x => x.IsValid,
              (isLoading, IsValid) => !isLoading && IsValid);


            LoginCommand = ReactiveCommand.CreateFromTask(
              async execute =>
              {
                  var random = new Random();
                  await Task.Delay(random.Next(400, 2000));
                  HostScreen.Router.Navigate.Execute(new CarsListViewModel()).Subscribe();
              }, canExecuteLogin);


            this.WhenAnyObservable(x => x.LoginCommand.IsExecuting)
              .StartWith(false)
              .ToProperty(this, x => x.IsLoading, out _isLoading);
        }
    }
}
