using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class FirstPage : DomainObject
    {
        private string _nameOrgRus;
        public string NameOrgRus
        {
            get => _nameOrgRus;
            set
            {
                _nameOrgRus = value;
                OnPropertyChanged(nameof(NameOrgRus));
            }
        }

        private string _nameOrgEng;
        public string NameOrgEng
        {
            get => _nameOrgEng;
            set
            {
                _nameOrgEng = value;
                OnPropertyChanged(nameof(NameOrgEng));
            }
        }

        private string _nameOrgRusFontSize;
        public string NameOrgRusFontSize
        {
            get => _nameOrgRusFontSize;
            set
            {
                _nameOrgRusFontSize = value;
                OnPropertyChanged(nameof(NameOrgRusFontSize));
            }
        }
        private string _nameOrgEngFontSize;
        public string NameOrgEngFontSize
        {
            get => _nameOrgEngFontSize;
            set
            {
                _nameOrgEngFontSize = value;
                OnPropertyChanged(nameof(NameOrgEngFontSize));
            }
        }
        private string _qrCodeSize;
        public string QrCodeSize
        {
            get => _qrCodeSize;
            set
            {
                _qrCodeSize = value;
                OnPropertyChanged(nameof(QrCodeSize));
            }
        }
        private string _nameOrgRusMargin;
        public string NameOrgRusMargin
        {
            get => _nameOrgRusMargin;
            set
            {
                _nameOrgRusMargin = value;
                OnPropertyChanged(nameof(NameOrgRusMargin));
            }
        }
        private string _nameOrgEngMargin;
        public string NameOrgEngMargin
        {
            get => _nameOrgEngMargin;
            set
            {
                _nameOrgEngMargin = value;
                OnPropertyChanged(nameof(NameOrgEngMargin));
            }
        }
        private string _qrCodeMargin;
        public string QrCodeMargin
        {
            get => _qrCodeMargin;
            set
            {
                _qrCodeMargin = value;
                OnPropertyChanged(nameof(QrCodeMargin));
            }
        }
    }
}
