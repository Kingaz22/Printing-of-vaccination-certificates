using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class User : DomainObject
    {

        private string _familyNameRus;
        private string _nameRus;
        private string _familyNameEng;
        private string _nameEng;
        private string _patronymic;
        private string _dateOfBirth;
        private string _passport;
        private string _identNumber;
        private UserFontSize _fontSize;
        private UserMargin _margin;


        /// <summary>
        /// Фамилия на русском
        /// </summary>
        public string FamilyNameRus
        {
            get => _familyNameRus;
            set
            {
                _familyNameRus = value;
                OnPropertyChanged(nameof(FamilyNameRus));
            }
        }
        /// <summary>
        /// Фпмилия на английском
        /// </summary>
        public string FamilyNameEng
        {
            get => _familyNameEng;
            set
            {
                _familyNameEng = value;
                OnPropertyChanged(nameof(FamilyNameEng));
            }
        }
        /// <summary>
        /// Имя на русском
        /// </summary>
        public string NameRus
        {
            get => _nameRus;
            set
            {
                _nameRus = value;
                OnPropertyChanged(nameof(NameRus));
            }
        }
        /// <summary>
        /// Имя на английском
        /// </summary>
        public string NameEng
        {
            get => _nameEng;
            set
            {
                _nameEng = value;
                OnPropertyChanged(nameof(NameEng));
            }
        }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value.Length == 8)
                {
                    value = value.Insert(2, ".").Insert(5, ".");
                }
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        /// <summary>
        /// Паспорт
        /// </summary>
        public string Passport
        {
            get => _passport;
            set
            {
                _passport = value;
                OnPropertyChanged(nameof(Passport));
            }
        }
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string IdentNumber
        {
            get => _identNumber;
            set
            {
                _identNumber = value;
                OnPropertyChanged(nameof(IdentNumber));
            }
        }
        /// <summary>
        /// Размер шрифта
        /// </summary>
        public UserFontSize FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }
        /// <summary>
        /// Расположение
        /// </summary>
        public UserMargin Margin
        {
            get => _margin;
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }

        public User()
        {
            FontSize = new UserFontSize();
            Margin = new UserMargin();
        }
    }
}
