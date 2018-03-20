using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject.Domain
{
    class Phone
    {
        public string personId { get; set; }
        public string customerCode { get; set; }
        public string phoneTypeCode { get; set; }
        public string phoneNumber { get; set; }

        public Phone(string personId, string customerCode, string phoneTypeCode, string phoneNumber)
        {
            this.personId = personId;
            this.customerCode = customerCode;
            this.phoneTypeCode = phoneTypeCode;
            this.phoneNumber = phoneNumber;
        }

        public string ToComboBoxFormat()
        {
            return this.phoneTypeCode + " - " + this.phoneNumber;
        }
    }
}
