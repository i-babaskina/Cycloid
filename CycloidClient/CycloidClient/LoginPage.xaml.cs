using CycloidClient.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CycloidClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void OkButtonOnClick(object sender, RoutedEventArgs e)
        {
            var res = await Requests.Login(LoginTextBox.Text, PasswordPasswordBox.Password);
            if(res == "Invalid login or password")
            {
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["token"] = res;
                this.Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
