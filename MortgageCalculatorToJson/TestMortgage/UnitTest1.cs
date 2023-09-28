namespace TestMortgage
{
    [TestClass]
    public class PaymentClass
    {
        [TestMethod]
        public void PaymentInstantiate_DateFormat_TotalCompute_PaymentClass()
        {
            //Assign
            Payment Test = new Payment(new DateOnly(2022, 9, 4), 100, 10, 200);

            //Assert
            Assert.IsNotNull(Test);
            Assert.AreEqual("04/09/2022", Test.Date.ToString("dd/MM/yyyy"));
            Assert.AreEqual(110, Test.Total);
        }
    }
    [TestClass]
    public class MortgageClass
    {
        [TestMethod]
        public void MortgageInstantiate()
        {
            //Assign
            Mortgage test = new Mortgage(30, 0.037m , 203000, new DateOnly(2021, 08, 01));

            //Assert
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void PayoffDateTest()
        {
            //Assign
            Mortgage test = new Mortgage(30, 0.037m, 203000, new DateOnly(2021, 08, 01));

            string expected = "2051/08/01"; // term is 30 years from 2021 so 2051
            //Assert
            Assert.AreEqual(expected, test.GetPayoffDate());
        }

        [TestMethod]
        public void RemainingPrincipleTest()
        {
            //Assign
            Mortgage test = new Mortgage(30, 0.037m, 203000, new DateOnly(2021, 08, 01));
            DateOnly randomDate = new DateOnly(2023, 09, 1);
            string expected = "195659.57"; // 195659.57 is how much is still owed

            //Assert
            Assert.AreEqual(expected, test.RemainingPrincipalAtDate(randomDate));
        }

        [TestMethod]
        public void InterestPaidTest()
        {
            //Assign
            Mortgage test = new Mortgage(30, 0.037m, 203000, new DateOnly(2021, 08, 01));
            DateOnly randomDate = new DateOnly(2023, 09, 1);
            string expected = "604.30"; // 604.30 is what the interest should be

            //Assert
            Assert.AreEqual(expected, test.InterestPaidAtDate(randomDate).ToString("0.00"));
        }

        [TestMethod]
        public void Save()
        {
            //Assign
            Mortgage test = new Mortgage(30, 0.037m, 203000, new DateOnly(2021, 08, 01));
            string expected = "{\"TermLengthInYears\":30,\"InterestRate\":\"0.037\",\"PrincipalAmount\":\"203000.00\",\"OriginationDate\":\"2021-08-01\"}";

            //Assert
            Assert.AreEqual(expected, test.Save());
        }
    }
}