using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class DateOfVaccination : Template
    {
        private string _date;
        public string Date
        {
            get => _date;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length == 8)
                    {
                        value = value.Insert(2, ".").Insert(5, ".");
                    }
                }
                
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
    }
}
