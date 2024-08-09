using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace AmiOutdoor.ViewModel
{
    internal class DateSelectionViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        private List<Dictionary<DateTime, string>> _events;
        public List<Dictionary<DateTime, string>> Events
        {
            get { return _events; }
            set 
            {
                if(Events == value) return;   
                _events = value;
                OnPropertyChanged(nameof(Events));
            }
        }

        private string? _event;
        public string? Event
        {
            get => _event;
            set
            {
                if (_event != value)
                {
                    _event = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(_event));
                }
            }
        }

        private string _textEvent;
        public string TextEvent
        {
            get { return _textEvent; }
            set
            {
                if (_textEvent == value) return;
                _textEvent = value;
                OnPropertyChanged(nameof(_textEvent));
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(_startDate));
                }
            }
        }


        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(_endDate));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public DateSelectionViewModel()
        {
            Events = new List<Dictionary<DateTime, string>>();
            this.CreateEvent = new RelayCommand(this.OnCreateEvent);
        }

        private void OnCreateEvent()
        {
            if (this.StartDate == null || this.EndDate == null)
            {
                Event = "Please select date(s) !";
            }
            else if (this.StartDate > this.EndDate)
            {
                Event = "The end date is before the start date !! :'O";
            }
            else if (this.StartDate == this.EndDate)
            {
                if (StartDate == null || EndDate == null) return;
                DateTime eventDate = (DateTime)StartDate;
                while (eventDate <= EndDate)
                {
                    Dictionary<DateTime, string> keyValues = new Dictionary<DateTime, string>();
                    keyValues.Add(eventDate, TextEvent);
                    Events.Add(keyValues);

                    eventDate = eventDate.AddDays(1); 
                }
                Event = "Event created on " + this.StartDate.ToString();
            }
            else
            {
                Event = "Event created :D";
            }
        }

        public ICommand CreateEvent { get; private set; }

    }
}

