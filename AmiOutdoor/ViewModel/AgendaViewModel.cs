using AmiLibrary.Models;
using System.ComponentModel;
using AmiLibrary.Services;
using System.Text.Json.Serialization;
using System.Windows.Automation;



namespace AmiOutdoor.ViewModel
{

    public class AgendaViewModel : INotifyPropertyChanged
    {
        private WeatherDetails _weatherDetails;
        private double _nebulosite; 
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
            }
        }



        public AgendaViewModel()
        {

            GetWeatherdetails();
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void Getnebulosite()
        {
            nebulosite = weatherDetails.Nebulosite.Totale;
        }
        private async void GetWeatherdetails()
        {
            weatherDetails = await new ServiceCalendar().GetWeatherDetails("Grenoble", DateTime.Today.ToString("yyyy-MM-dd") +" 05:00:00");
            
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

