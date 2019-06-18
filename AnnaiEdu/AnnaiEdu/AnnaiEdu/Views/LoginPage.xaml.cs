using AnnaiEdu.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnnaiEdu.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPageBase<LoginViewModel>
    {
		public LoginPage ()
		{
			InitializeComponent ();
		}

        public LoginPage(Entry usernameEntry, Entry passwordEntry, Button loginButton, Label messageLabel, ActivityIndicator loginActivityIndicator)
        {
            UsernameEntry = usernameEntry;
            PasswordEntry = passwordEntry;
            LoginButton = loginButton;
            this.messageLabel = messageLabel;
            LoginActivityIndicator = loginActivityIndicator;
        }
    }
}