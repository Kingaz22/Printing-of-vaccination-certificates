using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class Template : DomainObject
    {
        private string _fontSize;
        public string FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }
        private string _margin;
        public string Margin
        {
            get => _margin;
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }
    }
}
