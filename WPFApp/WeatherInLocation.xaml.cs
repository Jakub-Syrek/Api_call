using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for WeatherInLocation.xaml
    /// </summary>
    public partial class WeatherInLocation : Page
    {
        public WeatherInLocation()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            
        }

        private async void loadWeather_Click(object sender, RoutedEventArgs e)
        {
            //Weathers response = await WeatherProcessor.LoadWeather();

            //double lat = response.coord.lat;
            //double lng = response.coord.lon;

            double lat = 35;
            double lng = 139;

            DemoLibrary.GeoLocation.GeoLocation results = await LocationProcessor.LoadLocation(lat, lng);
            
            //Temp_min.Text = response.main.temp_min.ToString();

           // Temp_max.Text = response.main.temp_max.ToString();

            //Description.Text = response.weather.FirstOrDefault(x => x.description != null).description;

            City.Text = results.results.First(x => x.formatted != null).formatted;
        }


    }
}
