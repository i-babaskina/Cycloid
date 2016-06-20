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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using static CycloidClient.DataAccess.Requests;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CycloidClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Device selectedDevice = new Device();
        Room selectedRoom = new Room();
        DispatcherTimer updateTimer = new DispatcherTimer();
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
            border.Visibility = Visibility.Collapsed;
            Rooms = await LoadRooms();
            RoomsListView.ItemsSource = Rooms;
            RoomsListView.SelectedIndex = 0;
            updateTimer.Interval = TimeSpan.FromSeconds(10);
            updateTimer.Tick += UpdateTimerOnTick;      
        }

        private async void UpdateTimerOnTick(object sender, object e)
        {
            selectedRoom  = await Requests.GetRoom(selectedRoom.Id);
            UpdateRoomInfo(selectedRoom);
        }

        private void RoomsListViewOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room selectedRoom = RoomsListView.SelectedItem as Room;
            UpdateRoomInfo(selectedRoom);
            updateTimer.Start();
        }

        void UpdateRoomInfo(Room room)
        {
            NameTextBlock.Text = room.Name;
            TemperatureTextBlock.Text = room.Temperature.ToString() + " °C";
            HumidityTextBlock.Text = "Humidity: " + room.Humidity.ToString() + "%";
            DevicesListView.ItemsSource = room.Device;
        }



        private void LogoutButtonOnClick(object sender, RoutedEventArgs e)
        {
            //TODO:
            Windows.Storage.ApplicationData.Current.LocalSettings.Values["token"] = "";
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void DevicesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ConfigDevice(e.ClickedItem as Device);
        }

        private void ConfigDevice(Device dev)
        {
            selectedDevice = dev;
            border.Visibility = Visibility.Visible;
            DeviceNameTb.Text = dev.Name;
            DeviceTypeTb.Text = dev.Type;
            IsAutomaticSwitch.IsOn = dev.IsAutomaticOnff;
            MinTempTb.Value = dev.OnTemperature;
            MaxTempTb.Value = dev.OffTemperature;
            StateSwich.IsOn = dev.State;
        }

        private async void SaveOnClick(object sender, RoutedEventArgs e)
        {
            border.Visibility = Visibility.Collapsed;
            selectedDevice.Name = DeviceNameTb.Text;
            selectedDevice.Type = DeviceTypeTb.Text;
            selectedDevice.IsAutomaticOnff = IsAutomaticSwitch.IsOn;
            selectedDevice.OnTemperature = MinTempTb.Value;
            selectedDevice.OffTemperature = MaxTempTb.Value;
            selectedDevice.State = StateSwich.IsOn;
            await UpdateDevice(selectedDevice);
        }
    }
}
