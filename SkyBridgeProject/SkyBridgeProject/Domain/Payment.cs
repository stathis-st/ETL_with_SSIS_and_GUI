using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject.Domain
{
    class Payment
    {
        public string casesId { get; set; }
        public string id { get; set; }
        public string loanCreditCardCode { get; set; }
        public DateTime paymentDate { get; set; }
        public decimal paymentAmount { get; set; }
        public string otherInfo { get; set; }

        public Payment(string casesId, string id, string loanCreditCardCode, DateTime paymentDate, decimal paymentAmount, string otherInfo)
        {
            this.casesId = casesId;
            this.id = id;
            this.loanCreditCardCode = loanCreditCardCode;
            this.paymentDate = paymentDate;
            this.paymentAmount = paymentAmount;
            this.otherInfo = otherInfo;
        }

    }
}
