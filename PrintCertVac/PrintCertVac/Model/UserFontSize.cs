using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCertVac.Model
{
    public class UserFontSize : DomainObject
    {
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string IdentNumber { get; set; }
    }
}
