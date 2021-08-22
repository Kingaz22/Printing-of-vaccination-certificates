using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class TemplateCert : DomainObject
    {
        public string NameTemplate { get; set; }


        public UserMargin UserMargin { get; set; }
        public UserFontSize UserFontSize { get; set; }

        public string DateOfVaccinationMargin { get; set; }
        public string DateOfVaccinationFontSize { get; set; }
        public Vaccine Vaccine { get; set; }
        public Doctor Doctor { get; set; }

        public string DateOfVaccination2Margin { get; set; }
        public string DateOfVaccination2FontSize { get; set; }
        public Vaccine Vaccine2 { get; set; }
        public Doctor Doctor2 { get; set; }

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

        public TemplateCert()
        {
            UserMargin = new UserMargin();
            UserFontSize = new UserFontSize();
            Vaccine = new Vaccine();
            Doctor = new Doctor();
            Vaccine2 = new Vaccine();
            Doctor2 = new Doctor();
            FirstPage = new FirstPage();

        }
    }
}
