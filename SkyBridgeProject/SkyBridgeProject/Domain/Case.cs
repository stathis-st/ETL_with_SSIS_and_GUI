using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyBridgeProject.Domain
{
    class Case
    {
        public string caseId { get; set; }
        public int creditCardLoan { get; set; }
        public string caseCode { get; set; }
        public string serviceAccount { get; set; }
        public string productCode { get; set; }
        public decimal loanAmountLimit { get; set; }
        public decimal nonExpCapital { get; set; }
        public decimal interestRate { get; set; }
        public decimal posoOfeilis { get; set; }
        public decimal statementBalance { get; set; }
        public decimal interests { get; set; }
        public DateTime assignmentDate { get; set; }
        public string caseState { get; set; }
        public DateTime expLoanCardDate { get; set; }
        public string facilityCode { get; set; }
        public int assignmentCode { get; set; }
        public decimal totalBalance { get; set; }
        public decimal assignmentTotalBalance { get; set; }
        public decimal assignmentNonExpAmount { get; set; }
        public decimal assignmentPosoOfeilis { get; set; }
        public decimal availableSpendingBalance { get; set; }
        public string recallCode { get; set; }
        public int caseBucket { get; set; }
        public int delayDays { get; set; }
        public string loanTarget { get; set; }

        public IList<Payment> paymentsList { get; set; }

        public Case(string id, int creditCardLoan, string caseCode, string serviceAccount, string productCode, decimal loanAmountLimit, decimal nonExpCapital, decimal interestRate, decimal posoOfeilis,
                     decimal statementBalance, decimal interests, DateTime assignmentDate, string caseState, DateTime expLoanCardDate, string facilityCode, int assignmentCode, decimal totalBalance,
                     decimal assignmentTotalBalance, decimal assignmentNonExpAmount, decimal assignmentPosoOfeilis, decimal availableSpendingBalance, string recallCode, int caseBucket, int delayDays, string loanTarget)
        {
            this.caseId = id;
            this.creditCardLoan = creditCardLoan;
            this.caseCode = caseCode;
            this.serviceAccount = serviceAccount;
            this.productCode = productCode;
            this.loanAmountLimit = loanAmountLimit;
            this.nonExpCapital = nonExpCapital;
            this.interestRate = interestRate;
            this.posoOfeilis = posoOfeilis;
            this.statementBalance = statementBalance;
            this.interests = interests;
            this.assignmentDate = assignmentDate;
            this.caseState = caseState;
            this.expLoanCardDate = expLoanCardDate;
            this.facilityCode = facilityCode;
            this.assignmentCode = assignmentCode;
            this.totalBalance = totalBalance;
            this.assignmentTotalBalance = assignmentTotalBalance;
            this.assignmentNonExpAmount = assignmentNonExpAmount;
            this.assignmentPosoOfeilis = assignmentPosoOfeilis;
            this.availableSpendingBalance = availableSpendingBalance;
            this.recallCode = recallCode;
            this.caseBucket = caseBucket;
            this.delayDays = delayDays;
            this.loanTarget = loanTarget;
        }


        public IList<string> getPaymentsComboBoxFormat()
        {
            IList<string> paymentListComboboxFormat = new List<string>();
            foreach (Payment payment in paymentsList)
            {
                paymentListComboboxFormat.Add(payment.id);
            }
            return paymentListComboboxFormat;
        }
    }
}
