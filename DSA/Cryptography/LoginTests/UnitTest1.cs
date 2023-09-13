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
    }
}