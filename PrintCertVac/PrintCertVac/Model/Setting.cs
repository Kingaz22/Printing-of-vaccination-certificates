using DevExpress.Mvvm;

namespace PrintCertVac.Model
{
    public class Setting : DomainObject
    {
        private bool _nameCharacterCasing;
        public bool NameCharacterCasing
        {
            get => _nameCharacterCasing;
            set
            {
                _nameCharacterCasing = value;
                OnPropertyChanged(nameof(NameCharacterCasing));
            }
        }

        private bool _fullNameCharacterCasing;
        public bool FullNameCharacterCasing
        {
            get => _fullNameCharacterCasing;
            set
            {
                _fullNameCharacterCasing = value;
                OnPropertyChanged(nameof(FullNameCharacterCasing));
            }
        }

        private bool _numberCharacterCasing;
        public bool NumberCharacterCasing
        {
            get => _numberCharacterCasing;
            set
            {
                _numberCharacterCasing = value;
                OnPropertyChanged(nameof(NumberCharacterCasing));
            }
        }

        private bool _numberIdCharacterCasing;
        public bool NumberIdCharacterCasing
        {
            get => _numberIdCharacterCasing;
            set
            {
                _numberIdCharacterCasing = value;
                OnPropertyChanged(nameof(NumberIdCharacterCasing));
            }
        }

        private bool _numberCheck;
        public bool NumberCheck
        {
            get => _numberCheck;
            set
            {
                _numberCheck = value;
                OnPropertyChanged(nameof(NumberCheck));
            }
        }

        private string _templateQrCode;
        public string TemplateQrCode
        {
            get => _templateQrCode;
            set
            {
                _templateQrCode = value;
                OnPropertyChanged(nameof(TemplateQrCode));
            }
        }

    }
}
