using SkyBridgeProject.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyBridgeProject.Forms
{
    public partial class Details : Form
    {
        private IList<Person> personList;
        public Details()
        {
            InitializeComponent();
            SkyBridgeDbHelper dbHelper = new SkyBridgeDbHelper("login", "password", "server_name", "dataBase_name");

            //SSIS CALL
            dbHelper.importAll();


            this.personList = dbHelper.getPersons();

            IList<string> comboBoxList = new List<string>();
            int maxLength = 0;
            foreach (Person person in this.personList)
            {
                string valueToAdd = person.ToComboBoxFormat();
                if (valueToAdd.Length > maxLength)
                {
                    maxLength = valueToAdd.Length;
                }
                comboBoxList.Add(valueToAdd);
            }
            int spacePerLetter = 7;
            cbPersons.Size = new Size(maxLength * spacePerLetter, cbPersons.Size.Height);
            cbPersons.DataSource = comboBoxList;
        }

        private void updateFieldsForPerson()
        {
            Person selectedPerson = null;
            foreach (Person person in this.personList)
            {
                if (cbPersons.Text.Equals(person.ToComboBoxFormat())){
                    selectedPerson = person;
                    break;
                }
            }

            clearPersonControls();
            clearCaseControls();
            clearPaymentControls();

            txtCustomerCode.Text = selectedPerson.customerCode;
            txtIdentityNumber.Text = selectedPerson.identityNumber;
            txtFirstName.Text = selectedPerson.firstName;
            txtLastName.Text = selectedPerson.lastName;
            txtFatherName.Text = selectedPerson.fatherName;
            txtProfession.Text = selectedPerson.profession;
            txtTaxCode.Text = selectedPerson.taxCode;
            txtBirthDate.Text = selectedPerson.birthDate.ToShortDateString();
            cbPhoneNumber.DataSource = selectedPerson.getPhoneListForComboFormat();
            cbCaseList.DataSource = selectedPerson.getCaseListForComboFormat();
            updateFieldsForCase();
        }

        private void updateFieldsForCase()
        {

            Person selectedPerson = null;
            foreach (Person person in this.personList)
            {
                if (cbPersons.Text.Equals(person.ToComboBoxFormat()))
                {
                    selectedPerson = person;
                    break;
                }
            }

            Case selectedCase = null;
            
            foreach (Case pCase in selectedPerson.casesList)
            {
                if (cbCaseList.Text.Equals(pCase.caseId))
                {
                    selectedCase = pCase;
                    break;
                }
            }

            clearCaseControls();
            
            txtCreditCardLoan.Text = selectedCase.caseCode;
            txtCaseCode.Text = selectedCase.caseCode;
            txtServiceAccount.Text = selectedCase.serviceAccount;
            txtProductCode.Text = selectedCase.productCode;
            txtLoanAmountLimit.Text = selectedCase.loanAmountLimit.ToString();
            txtNonExpCapital.Text = selectedCase.nonExpCapital.ToString();
            txtInterestRate.Text = selectedCase.interestRate.ToString();
            txtPosoOfeilis.Text = selectedCase.posoOfeilis.ToString();
            txtStatementBalance.Text = selectedCase.statementBalance.ToString();
            txtInterests.Text = selectedCase.interests.ToString();
            txtAssignmentDate.Text = selectedCase.assignmentDate.ToShortDateString();
            txtCaseState.Text = selectedCase.caseState;
            txtExpLoanCardDate.Text = selectedCase.expLoanCardDate.ToShortDateString();
            txtFacilityCode.Text = selectedCase.facilityCode;
            txtAssignmentCode.Text = selectedCase.assignmentCode.ToString();
            txtTotalBalance.Text = selectedCase.totalBalance.ToString();
            txtAssignmentTotalBalance.Text = selectedCase.assignmentTotalBalance.ToString();
            txtAssignmentNonExpAmount.Text = selectedCase.assignmentNonExpAmount.ToString();
            txtAssignmentPosoOfeilis.Text = selectedCase.assignmentPosoOfeilis.ToString();
            txtAvailableSpendingBalance.Text = selectedCase.availableSpendingBalance.ToString();
            txtRecallCode.Text = selectedCase.recallCode;
            txtCaseBucket.Text = selectedCase.caseBucket.ToString();
            txtDelayDays.Text = selectedCase.delayDays.ToString();
            txtLoanTarget.Text = selectedCase.loanTarget;
            cbPayments.DataSource = selectedCase.getPaymentsComboBoxFormat();     
        }

        private void UpdateFieldsForPayments()
        {
            Person selectedPerson = null;
            foreach (Person person in this.personList)
            {
                if (cbPersons.Text.Equals(person.ToComboBoxFormat()))
                {
                    selectedPerson = person;
                    break;
                }
            }
            Case selectedCase = null;
            foreach (Case pCase in selectedPerson.casesList)
            {
                if (cbCaseList.Text.Equals(pCase.caseId))
                {
                    selectedCase = pCase;
                    break;
                }
            }

            Payment selectedPayment = null;

            foreach (Payment pPayment in selectedCase.paymentsList)
            {
                if (cbPayments.Text.Equals(pPayment.id))
                {
                    selectedPayment = pPayment;
                    break;
                }
            }

            clearPaymentControls();

            txtLoanCreditCardCode.Text = selectedPayment.loanCreditCardCode;
            txtPaymentDate.Text = selectedPayment.paymentDate.ToShortDateString();
            txtPaymentAmount.Text = selectedPayment.paymentAmount.ToString();
            txtOtherInfo.Text = selectedPayment.otherInfo;
        }

        private void cbPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFieldsForPerson();
        }

        private void cbCaseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFieldsForCase();
        }

        private void cbPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldsForPayments();
        }

        private void clearPersonControls()
        {
            txtCustomerCode.Text = "";
            txtIdentityNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            txtProfession.Text = "";
            txtTaxCode.Text = "";
            txtBirthDate.Text = "";
        }

        private void clearCaseControls()
        {
            txtCreditCardLoan.Text = "";
            txtCaseCode.Text = "";
            txtServiceAccount.Text = "";
            txtProductCode.Text = "";
            txtLoanAmountLimit.Text = "";
            txtNonExpCapital.Text = "";
            txtInterestRate.Text = "";
            txtPosoOfeilis.Text = "";
            txtStatementBalance.Text = "";
            txtInterests.Text = "";
            txtAssignmentDate.Text = "";
            txtCaseState.Text = "";
            txtExpLoanCardDate.Text = "";
            txtFacilityCode.Text = "";
            txtAssignmentCode.Text = "";
            txtTotalBalance.Text = "";
            txtAssignmentTotalBalance.Text = "";
            txtAssignmentNonExpAmount.Text = "";
            txtAssignmentPosoOfeilis.Text = "";
            txtAvailableSpendingBalance.Text = "";
            txtRecallCode.Text = "";
            txtCaseBucket.Text = "";
            txtDelayDays.Text = "";
            txtLoanTarget.Text = "";
        }

        private void clearPaymentControls()
        {
            txtLoanCreditCardCode.Text = "";
            txtPaymentDate.Text = "";
            txtPaymentAmount.Text = "";
            txtOtherInfo.Text = "";
        }

        private void Details_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
