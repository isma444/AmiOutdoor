using System;
using System.Collections.Generic;
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

        public DateSelectionViewModel()
        {
            this.CreateEvent = new RelayCommand(this.OnCreateEvent);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

