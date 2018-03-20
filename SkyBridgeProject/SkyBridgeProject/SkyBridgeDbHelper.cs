using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using SkyBridgeProject.Domain;
using System.Collections.ObjectModel;
using Microsoft.SqlServer.Dts.Runtime;
using System.IO;

namespace SkyBridgeProject
{
    class SkyBridgeDbHelper
    {
        private SqlConnection sqlConnection;

        public SkyBridgeDbHelper(string username, string password, string serverUrl, string database)
        {
            string connectionstring =
                "user id=" + username + ";" +
                "password=" + password + ";" +
                "server=" + serverUrl + ";" +
                "database=" + database + ";" +
                "Trusted_Connection=yes;" +
                "connection timeout=30";
            this.sqlConnection = new SqlConnection(connectionstring);
        }

        public void importAll()
        {
            Application application = new Application();

            String path = Directory.GetCurrentDirectory().ToString();

            string packageLocation = path + @"\FromTextToDB.dtsx";
            Package package = application.LoadPackage(packageLocation, null);
            DTSExecResult pkgResults;

            Parameters parameters = package.Parameters;

            parameters["CasePersonFilePath"].Value = path + @"\TempOutputDirectory\OUT_FIRSTCALL_CRS_CASEPERSON_20101018.txt";
            parameters["CasesFilePath"].Value = path + @"\TempOutputDirectory\OUT_FIRSTCALL_CRS_CASES_20101018.txt";
            parameters["PaymentsFilePath"].Value = path + @"\TempOutputDirectory\OUT_FIRSTCALL_CRS_PAYMENTS_20101018.txt";
            parameters["PersonFilePath"].Value = path + @"\TempOutputDirectory\OUT_FIRSTCALL_CRS_PERSON_20101018.txt";
            parameters["PhoneFilePath"].Value = path + @"\TempOutputDirectory\OUT_FIRSTCALL_CRS_PHONE_20101018.txt";

            pkgResults = package.Execute();

            if (pkgResults == DTSExecResult.Success)
                Console.WriteLine("Package ran successfully");

            else
            {
                Console.WriteLine("Package failed");
            }
        }

        public IList<Person> getPersons()
        {
            IList<Person> personList = new List<Person>();

            try
            {
                this.sqlConnection.Open();
                SqlCommand personsCommand = new SqlCommand("SELECT * FROM Person;", sqlConnection);
                SqlDataReader personsReader = null;
                personsReader = personsCommand.ExecuteReader();
                while (personsReader.Read())
                {
                    string id = (string)personsReader[0];
                    string customerCode = (string)personsReader[1];
                    string lastName = (string)personsReader[2];
                    string firstName = (string)personsReader[3];
                    string fatherName = (string)personsReader[4];
                    string identityNumber = (string)personsReader[5];
                    DateTime birthDate = (DateTime)personsReader[6];
                    string profession = (string)personsReader[7];
                    string taxCode = (string)personsReader[8];
                    Person person = new Person(id, customerCode, lastName, firstName, fatherName, identityNumber, birthDate, profession, taxCode);
                    personList.Add(person);
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.ToString());
            }
            finally
            {
                this.sqlConnection.Close();
            }

            foreach (Person person in personList)
            {
                person.phoneList = getPhonesForPerson(person);
                person.casesList = getCasesForPerson(person);
            }
            return personList;
        }

        public IList<Phone> getPhonesForPerson(Person person)
        {
            IList<Phone> phoneList = new List<Phone>();
            try
            {
                this.sqlConnection.Open();
                SqlCommand phonesCommand = new SqlCommand("SELECT * FROM Phone WHERE PersonId = '" + person.id + "' AND CustomerCode = '" + person.customerCode + "'", sqlConnection);
                SqlDataReader phonesReader = null;
                phonesReader = phonesCommand.ExecuteReader();
                while (phonesReader.Read())
                {
                    string personId = (string)phonesReader[0];
                    string customerCode = (string)phonesReader[1];
                    string phoneTypeCode = (string)phonesReader[2];
                    string phoneNumber = (string)phonesReader[3];
                    Phone phone = new Phone(personId, customerCode, phoneTypeCode, phoneNumber);
                    phoneList.Add(phone);
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.ToString());
            }
            finally
            {
                this.sqlConnection.Close();
            }
            return phoneList;
        }

        public IList<Case> getCasesForPerson(Person person)
        {
            IList<Case> caseList = new List<Case>();
            try
            {
                this.sqlConnection.Open();
                SqlCommand casesCommand = new SqlCommand("SELECT * FROM Cases as cs INNER JOIN CasePerson as cp ON cs.id = cp.casesId AND cp.PersonId = '" + person.id + "';", sqlConnection);
                SqlDataReader casesReader = null;
                casesReader = casesCommand.ExecuteReader();
                while (casesReader.Read())
                {
                    string caseId = (string)casesReader[0];
                    int creditCardLoan = (int)casesReader[1];
                    string caseCode = (string)casesReader[2];
                    string serviceAccount = (string)casesReader[3];
                    string productCode = (string)casesReader[4];
                    decimal loanAmountLimit = (decimal)casesReader[5];
                    decimal nonExpCapital = (decimal)casesReader[6];
                    decimal interestRate = (decimal)casesReader[7];
                    decimal posoOfeilis = (decimal)casesReader[8];
                    decimal statementBalance = (decimal)casesReader[9];
                    decimal interests = (decimal)casesReader[10];
                    DateTime assignmentDate = (DateTime)casesReader[11];
                    string caseState = (string)casesReader[12];
                    DateTime expLoanCardDate = (DateTime)casesReader[13];
                    string facilityCode = (string)casesReader[14];
                    int assignmentCode = (int)casesReader[15];
                    decimal totalBalance = (decimal)casesReader[16];
                    decimal assignmentTotalBalance = (decimal)casesReader[17];
                    decimal assignmentNonExpAmount = (decimal)casesReader[18];
                    decimal assignmentPosoOfeilis = (decimal)casesReader[19];
                    decimal availableSpendingBalance = (decimal)casesReader[20];
                    string recallCode = (string)casesReader[21];
                    int caseBucket = (int)casesReader[22];
                    int delayDays = (int)casesReader[23];
                    string loanTarget = (string)casesReader[24];
                    Case personsCase = new Case(caseId, creditCardLoan, caseCode, serviceAccount, productCode, loanAmountLimit, nonExpCapital, interestRate, posoOfeilis, statementBalance, interests, assignmentDate, caseState, expLoanCardDate, facilityCode, assignmentCode, totalBalance, assignmentTotalBalance, assignmentNonExpAmount, assignmentPosoOfeilis, availableSpendingBalance, recallCode, caseBucket, delayDays, loanTarget);
                    caseList.Add(personsCase);
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.ToString());
            }
            finally
            {
                this.sqlConnection.Close();
            }

            foreach (Case paymentCase in caseList)
            {
                paymentCase.paymentsList = getPaymentsForCase(paymentCase);
            }

            return caseList;
        }

        public IList<Payment> getPaymentsForCase(Case paymentCase)
        {
            IList<Payment> paymentList = new List<Payment>();

            try
            {
                this.sqlConnection.Open();
                SqlCommand paymentsCommand = new SqlCommand("SELECT pay.CasesId, pay.Id, pay.LoanCreditCardCode, pay.PaymentDate, pay.PaymentAmount, pay.OtherInfo FROM Payments as pay " +
                                                            "INNER JOIN Cases as cs ON pay.CasesId = cs.Id WHERE pay.CasesId = '" + paymentCase.caseId + "';", sqlConnection);
                SqlDataReader paymentsReader = null;
                paymentsReader = paymentsCommand.ExecuteReader();
                while (paymentsReader.Read())
                {
                    string caseId = (string)paymentsReader[0];
                    string id = (string)paymentsReader[1];
                    string LoanCreditCardCode = (string)paymentsReader[2];
                    DateTime paymentDate = (DateTime)paymentsReader[3];
                    decimal paymentAmount = (decimal)paymentsReader[4];
                    string otherInfo = (string)paymentsReader[5];
                    Payment paymentsForCase = new Payment(caseId, id, LoanCreditCardCode, paymentDate, paymentAmount, otherInfo);
                    paymentList.Add(paymentsForCase);
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.ToString());
            }
            finally
            {
                this.sqlConnection.Close();
            }

            return paymentList;
        }

    }
}
