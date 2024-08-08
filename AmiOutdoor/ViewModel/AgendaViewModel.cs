using AmiLibrary.Models;
using System.ComponentModel;
using AmiLibrary.Services;
using System.Text.Json.Serialization;
using System.Windows.Automation;
using System.Collections.ObjectModel;



namespace AmiOutdoor.ViewModel
{

    public class AgendaViewModel : INotifyPropertyChanged
    {
        private WeatherDetails _weatherDetails;
        private double _nebulosite;
        public ObservableCollection<GridCell> DataList { get; set; }
        public double nebulosite {
            get
            {
                return _nebulosite;
            }
            set 
            {
                if (_nebulosite == value) return;
                _nebulosite = value;
                OnPropertyChanged(nameof(nebulosite));
            }
        }
        private string _content;
        public int Row { get; set; }
        public int Column { get; set; }
        private ServiceCalendar serviceCalendar = new ServiceCalendar();
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
                
            }
        }

        public WeatherDetails weatherDetails {
            get
            {
                return _weatherDetails;
            }
            set
            {
                if (value == _weatherDetails) return;
                _weatherDetails = value;
                OnPropertyChanged(nameof(weatherDetails));
                Getnebulosite();
                AddDataInCell();
            }
        }

   

        public AgendaViewModel()
        {
            DataList = new ObservableCollection<GridCell>();
            GetWeatherdetails();
      
        }


        private async void AddDataInCell()
        {
            var keys = new JsonDeserialisez().GetKeyList(serviceCalendar.GetWeatherData());

            var i = 0;
            foreach (var key in keys)
            {
                if (i >= 6) return;
                var weatherDetail = await serviceCalendar.GetWeatherDetails("Grenoble", key);
                DataList.Add( new GridCell { Row = 0, Column = i, Content = weatherDetail.Nebulosite.Totale.ToString(), WeatherKey = "2024-08-08 05:00:00" });
                i++;
            }
           
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void Getnebulosite()
        {
            nebulosite = weatherDetails.Nebulosite.Totale;
        }
        private async void GetWeatherdetails()
        {
            weatherDetails = await serviceCalendar.GetWeatherDetails("Grenoble", DateTime.Today.ToString("yyyy-MM-dd") +" 05:00:00");
   
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GridCell : INotifyPropertyChanged
    {
        private string _content;
        public int Row { get; set; }
        public int Column { get; set; }
        public string WeatherKey {get; set; }
        public string Content
        {
            get => _content;
            set
            {
                if (_content == value) return;
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


