using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using Newtonsoft.Json;

namespace Tehtava_9___Junatiedot
{
    public partial class MainWindow : Window
    {

        List<Train> trains = new List<Train>();
        List<ComboBoxItem> cities = new List<ComboBoxItem>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if (cbCity.SelectedIndex >= 0) {
                string city = cbCity.SelectedValue.ToString();
                CallLongRunningMethod(city);
                lblStatus.Content = "Haetaan..";
            }
        }

        private async void CallLongRunningMethod(string city)
        {
            string result = await LongRunningMethodAsync(city);
            var deserializedProduct = JsonConvert.DeserializeObject<List<Train>>(result);

            foreach (var train in deserializedProduct)
            {
                Train t = new Train();
                t.trainNumber = train.trainNumber;
                t.cancelled = train.cancelled;
                t.departureDate = train.departureDate;
                trains.Add(t);

                Console.WriteLine(train.trainNumber);

                /*
                foreach (var item in train.timeTableRows)
                {
                    //t.timeTableRows.Add(item);
                    Console.WriteLine("Station: {0}, actualTime: {1}", item.stationShortCode, item.actualTime);
                }*/
            }

            /*
            dynamic j = JsonConvert.DeserializeObject(result);
            foreach (var c in j)
                Console.WriteLine(c["trainNumber"]);
            */

            lblStatus.Content = "";
            datagridJunat.Visibility = Visibility.Visible;
            datagridJunat.ItemsSource = trains;
        }

        private Task<string> LongRunningMethodAsync(string city)
        {
            return Task.Run<string>(() => LongRunningMethod(city));
        }

        private string LongRunningMethod(string city)
        {
            Console.Write(city);
            WebClient wc = new WebClient();
            string json = wc.DownloadString("http://rata.digitraffic.fi/api/v1/live-trains?station="+city+"&arrived_trains=5&arriving_trains=5&departed_trains=5&departing_trains=5");
            return json;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
        }

        private void cbCity_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbCity.SelectedValuePath = "Key";
            this.cbCity.DisplayMemberPath = "Value";
            this.cbCity.Items.Add(new KeyValuePair<string, string>("JY", "Jyväskylä"));
            this.cbCity.Items.Add(new KeyValuePair<string, string>("HKI", "Helsinki"));

        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            datagridJunat.Visibility = Visibility.Hidden;
            datagridJunat.Columns.Clear();
            trains.Clear();
            datagridJunat.ItemsSource = "";

        }
    }
}
