﻿using AmiLibrary.Models;
using System.ComponentModel;
using AmiLibrary.Services;
using System.Text.Json.Serialization;
using System.Windows.Automation;
using System.Collections.ObjectModel;



namespace AmiOutdoor.ViewModel
{

    public class AgendaViewModel : INotifyPropertyChanged
    {
        private IServiceCalendar _serviceCalendar;
        public ObservableCollection<GridCell> DataList { get; set; }

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

        private WeatherDetails _weatherDetails;
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
                AddDataInCell();
            }
        }
        private async void AddDataInCell()
        {
            var keys = new JsonDeserialisez().GetKeyList(_serviceCalendar.GetWeatherData());

            var i = 0;
            foreach (var key in keys)
            {
                if (i >= 6) return;
                var weatherDetail = await _serviceCalendar.GetWeatherDetails("Grenoble", key);
                DataList.Add(new GridCell { Row = 0, Column = i, Nebulosite = weatherDetail.Nebulosite.Totale, Rain = weatherDetail.Pluie});
                i++;
            }

        }

        public AgendaViewModel()
        {
            DataList = new ObservableCollection<GridCell>();
            _serviceCalendar = new ServiceCalendar();
            GetWeatherdetails();
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        private async void GetWeatherdetails()
        {
            weatherDetails = await _serviceCalendar.GetWeatherDetails("Grenoble", DateTime.Today.ToString("yyyy-MM-dd") +" 05:00:00");
   
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
        public int Row { get; set; }
        public int Column { get; set; }
        public string WeatherKey {get; set; }

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


