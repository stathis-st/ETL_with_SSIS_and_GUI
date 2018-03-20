using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject.Domain
{
    class Person
    {
        public string id {get; set; }
        public string customerCode { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string fatherName { get; set; } 
        public string identityNumber { get; set; }
        public DateTime birthDate { get; set; }
        public string profession { get; set; }
        public string taxCode { get; set; }

        public IList<Phone> phoneList { get; set; }

        public IList<Case> casesList { get; set; }

        public Person(string id, string customerCode, string lastName, string firstName, string fatherName, string identityNumber, DateTime birthDate, string profession, string taxCode)
        {
            this.id = id;
            this.customerCode = customerCode;
            this.lastName = lastName;
            this.firstName = firstName;
            this.fatherName = fatherName;
            this.identityNumber = identityNumber;
            this.birthDate = birthDate;
            this.profession = profession;
            this.taxCode = taxCode;
        }

        public string ToComboBoxFormat()
        {
            return "[" + this.lastName + " " + this.firstName + "] - " + this.identityNumber;
        }

        public IList<string> getPhoneListForComboFormat()
        {
            IList<string> phoneListForComboFormat = new List<string>();
            foreach (Phone phone in phoneList)
            {
                phoneListForComboFormat.Add(phone.ToComboBoxFormat());
            }
            return phoneListForComboFormat;
        }

        public IList<string> getCaseListForComboFormat()
        {
            IList<string> caseListForComboFormat = new List<string>();
            foreach (Case pCase in casesList)
            {
                caseListForComboFormat.Add(pCase.caseId);
            }
            return caseListForComboFormat;
        }

    }


}
