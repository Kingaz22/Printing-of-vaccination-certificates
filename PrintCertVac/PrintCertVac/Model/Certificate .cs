using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class Certificate : DomainObject
    {
        private int ?_contractNumber;
        public int ?ContractNumber
        {
            get => _contractNumber;
            set
            {
                _contractNumber = value;
                OnPropertyChanged(nameof(ContractNumber));
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private DateTime _dateRecord;
        public DateTime DateRecord
        {
            get => _dateRecord;
            set
            {
                _dateRecord = value;
                OnPropertyChanged(nameof(DateRecord));
            }
        }
        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private DateOfVaccination _dateOfVaccination;
        public DateOfVaccination DateOfVaccination
        {
            get => _dateOfVaccination;
            set
            {
                _dateOfVaccination = value;
                OnPropertyChanged(nameof(DateOfVaccination));
            }
        }
        private Vaccine _vaccine;
        public Vaccine Vaccine
        {
            get => _vaccine;
            set
            {
                _vaccine = value;
                OnPropertyChanged(nameof(Vaccine));
            }
        }
        private string _partVac;
        public string PartVac
        {
            get => _partVac;
            set
            {
                _partVac = value;
                OnPropertyChanged(nameof(PartVac));
            }
        }
        private Doctor _doctor;
        public Doctor Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }

        private DateOfVaccination _dateOfVaccination2;
        public DateOfVaccination DateOfVaccination2
        {
            get => _dateOfVaccination2;
            set
            {
                _dateOfVaccination2 = value;
                OnPropertyChanged(nameof(DateOfVaccination2));
            }
        }
        private Vaccine _vaccine2;
        public Vaccine Vaccine2
        {
            get => _vaccine2;
            set
            {
                _vaccine2 = value;
                OnPropertyChanged(nameof(Vaccine2));
            }
        }
        private string _partVac2;
        public string PartVac2
        {
            get => _partVac2;
            set
            {
                _partVac2 = value;
                OnPropertyChanged(nameof(PartVac2));
            }
        }
        private Doctor _doctor2;
        public Doctor Doctor2
        {
            get => _doctor2;
            set
            {
                _doctor2 = value;
                OnPropertyChanged(nameof(Doctor2));
            }
        }

        private FirstPage _firstPage;
        public FirstPage FirstPage
        {
            get => _firstPage;
            set
            {
                _firstPage = value;
                OnPropertyChanged(nameof(FirstPage));
            }
        }

        public Certificate()
        {
            User = new User();
            DateOfVaccination = new DateOfVaccination();
            Vaccine = new Vaccine();
            Doctor = new Doctor();
            DateOfVaccination2 = new DateOfVaccination();
            Vaccine2 = new Vaccine();
            Doctor2 = new Doctor();
            FirstPage = new FirstPage();
        }

        public Certificate(TemplateCert templateCert)
        {
            User = new User
            {
                Margin = templateCert.UserMargin,
                FontSize = templateCert.UserFontSize
            };
            DateOfVaccination = new DateOfVaccination
            {
                FontSize = templateCert.DateOfVaccinationFontSize,
                Margin = templateCert.DateOfVaccinationMargin
            };
            Vaccine = templateCert.Vaccine;
            Doctor = templateCert.Doctor;
            DateOfVaccination2 = new DateOfVaccination
            {
                FontSize = templateCert.DateOfVaccination2FontSize,
                Margin = templateCert.DateOfVaccination2Margin
            };
            Vaccine2 = templateCert.Vaccine2;
            Doctor2 = templateCert.Doctor2;
            FirstPage = templateCert.FirstPage;
        }
    }
}
