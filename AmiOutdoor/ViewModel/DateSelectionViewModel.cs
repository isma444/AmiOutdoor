using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AmiOutdoor.ViewModel
{
    internal class DateSelectionViewModel : INotifyPropertyChanged
    {
        private DateTime? _startDate;
        private DateTime? _endDate;

        public event PropertyChangedEventHandler PropertyChanged;
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


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

