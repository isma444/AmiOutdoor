using AmiLibrary.Models;
using System.ComponentModel;
using AmiLibrary.Services;
using System.Text.Json.Serialization;
using System.Windows.Automation;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace AmiOutdoor.ViewModel
{

    public class AgendaViewModel : INotifyPropertyChanged
    {
        private IServiceCalendar _serviceCalendar;
        public ObservableCollection<GridCell> DataList { get; set; }

        #region INotifyPropertyChanged
        private WeatherDetails _weatherDetails;
        public WeatherDetails weatherDetails
        {
            get
            {
                return _weatherDetails;
            }
            set
            {
                if (value == _weatherDetails) return;
                _weatherDetails = value;
                OnPropertyChanged(nameof(weatherDetails));
                AddDataInCell();
            }
        }
        private double _nebulosite;
        public double Nebulosite
        {
            get
            {
                return _nebulosite;
            }
            set
            {
                if (_nebulosite == value) return;
                _nebulosite = value;
                OnPropertyChanged(nameof(Nebulosite));
            }
        }
        private double _rain;
        public double Rain
        {
            get
            {
                return _rain;
            }
            set
            {
                if (_rain == value) return;
                _rain = value;
                OnPropertyChanged(nameof(Rain));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion


        public AgendaViewModel()
        {
            DataList = new ObservableCollection<GridCell>();
            _serviceCalendar = new ServiceCalendar();
            GetWeatherdetails();
        }

        private async void GetWeatherdetails()
        {
            weatherDetails = await _serviceCalendar.GetWeatherDetails("Grenoble", DateTime.Today.ToString("yyyy-MM-dd") + " 05:00:00");

        }
       


        private async void AddDataInCell()
        {
            var keys = new JsonDeserialisez().GetKeyList(_serviceCalendar.GetWeatherData());

            var i = 0;
            foreach (var key in keys.Select(key => DateTime.Parse(key)).GroupBy(dateTime => dateTime.Date).Select(group => group.First()).Take(7)) 
            {
                
                var weatherDetail = await _serviceCalendar.GetWeatherDetails("Grenoble", key.ToString("yyyy-MM-dd HH:mm:ss"));
                DataList.Add(new GridCell { 
                    Row = 0,
                    Column = i,
                    Nebulosite = weatherDetail.Nebulosite.Totale,
                    Rain = weatherDetail.Pluie,
                    Dates = key.ToString("dd/MM/y")
                    });
                i++;
            }
        }

    }

    public class GridCell : INotifyPropertyChanged
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string WeatherKey {get; set; }

        public string Dates { get; set; }

        private double _nebulosite;
        public double Nebulosite
        {
            get
            {
                return _nebulosite;
            }
            set
            {
                if (_nebulosite == value) return;
                _nebulosite = value;
                OnPropertyChanged(nameof(Nebulosite));
            }
        }

        private double _rain;
        public double Rain
        {
            get
            {
                return _rain;
            }
            set
            {
                if (_rain == value) return;
                _rain = value;
                OnPropertyChanged(nameof(Rain));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


