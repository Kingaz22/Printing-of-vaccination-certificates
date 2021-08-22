using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class Report : DomainObject
    {
        private DateTime _dateTime;
        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }

        private int _incoming;
        public int Incoming
        {
            get => _incoming;
            set
            {
                _incoming = value;
                OnPropertyChanged(nameof(Incoming));
            }
        }

        private int _sale;
        public int Sale
        {
            get => _sale;
            set
            {
                _sale = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }

        private int _spoiled;
        public int Spoiled
        {
            get => _spoiled;
            set
            {
                _spoiled = value;
                OnPropertyChanged(nameof(Spoiled));
            }
        }

        private int _total;
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

    }
}
