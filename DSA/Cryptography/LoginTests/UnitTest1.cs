namespace LoginTests
{
    [TestClass]
    public class CustomerLoginTests
    {
        [TestMethod]
        public void AreThereThreeCustomers_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            string Names = "";
            string Expected = "John Smith Dan Smith Jacki Smith ";

            //Act
            Store.IntitalizeThreeCustomers();
            foreach(var CustomerDictionary in Store.Customers)
            {
                Customer Customer = CustomerDictionary.Value;
                Names = Names + Customer.Name + " ";
            }
            
            //Assert
            Assert.AreEqual(3, Store.Customers.Count());
            Assert.AreEqual(Expected, Names);
        }

        [TestMethod]
        public void ArePasswordsUniquelyHashed_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            Store.IntitalizeThreeCustomers();
            string[] hashedPasswords = new string[3];

            //Act
            int i = 0;
            foreach (var CustomerDictionary in Store.Customers)
            {
                Customer Customer = CustomerDictionary.Value;
                hashedPasswords[i++] = Customer.HashedPassword;
            }

            //Assert
            Assert.AreNotEqual(hashedPasswords[0], hashedPasswords[1]);
            Assert.AreNotEqual(hashedPasswords[2], hashedPasswords[1]);

        }

        [TestMethod]
        public void CanILoginToEachAccount_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            Store.IntitalizeThreeCustomers();
            string[] hashedPasswords = new string[3];

            //Act
            int i = 0;
            string Password = "password";
            foreach (var CustomerDictionary in Store.Customers)
            {
                Customer Customer = CustomerDictionary.Value;
                hashedPasswords[i++] = Customer.HashedPassword;

                //Assert
                Assert.IsTrue(Store.LoginSucessfull(Customer, Password));
            }
        }


        [TestMethod]
        public void AreCreditCardsUniquelyEncrypted_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            Store.IntitalizeThreeCustomers();
            string[] EncryptedCreditCards = new string[3];

            //Act
            int i = 0;
            foreach (var CustomerDictionary in Store.Customers)
            {
                Customer Customer = CustomerDictionary.Value;
                EncryptedCreditCards[i++] = Customer.HashedPassword;
            }

            //Assert
            Assert.AreNotEqual(EncryptedCreditCards[0], EncryptedCreditCards[1]);
            Assert.AreNotEqual(EncryptedCreditCards[2], EncryptedCreditCards[1]);
        }

        [TestMethod]
        public void DecryptAndMatchCreditCards_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            Store.IntitalizeThreeCustomers();
            string[] DecryptCreditCards = new string[Store.Customers.Count()];

            //Act
            int i = 0;
            foreach (var CustomerDictionary in Store.Customers)
            {
                Customer Customer = CustomerDictionary.Value;
                DecryptCreditCards[i++] = Customer.DecryptCreditCard("password");
            }

            //Assert
            Assert.AreEqual(DecryptCreditCards[0], DecryptCreditCards[1]);
            Assert.AreEqual(DecryptCreditCards[2], DecryptCreditCards[1]);

        }

        [TestMethod]
        public void FindCustomer_CustomerLogin()
        {
            //Arrange
            CustomerLogin Store = new CustomerLogin();
            Store.IntitalizeThreeCustomers();
            Store.Customers.Add("Leo", new Customer("Leo LastName", "fakeemail@gmail.com", "678979686786754", "pa565words"));

            //Act
            Customer Leo = Store.FindCustomerByNameAndPassword("Leo LastName", "pa565words");

            //Assert
            Assert.AreEqual("Leo LastName", Leo.Name);
            Assert.AreEqual("678979686786754", Leo.DecryptCreditCard("pa565words"));
            Assert.AreNotEqual("pa565words", Leo.HashedPassword);
            Assert.IsTrue(Leo.VerifyPassword("pa565words"));
        }
    }
}