using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class Record : DomainObject
    {
        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
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

    }
}
