using CycloidClient.DataAccess;
using CycloidClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CycloidClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
            }
        } 

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
           
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await Init();
        }

        private async Task Init()
        {
           Rooms = await Requests.LoadRooms();
            RoomsListView.ItemsSource = Rooms;
            RoomsListView.SelectedIndex = 0;
        }


        private void RoomsListViewOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room temp = RoomsListView.SelectedItem as Room;
            NameTextBlock.Text = temp.Name;
            TemperatureTextBlock.Text = temp.Temperature.ToString()+ " °C";
            HumidityTextBlock.Text = "Humidity: " + temp.Humidity.ToString() + "%";
            DevicesListView.ItemsSource = temp.Device;
        }

        private void LogoutButtonOnClick(object sender, RoutedEventArgs e)
        {
            //TODO:
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["token"] = "";
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void DevicesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            

        }
    }
}
