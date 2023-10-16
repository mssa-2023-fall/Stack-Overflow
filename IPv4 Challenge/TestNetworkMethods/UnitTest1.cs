using IPV4Translator;

namespace TestNetworkMethods
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Constructor()
        {
            //Assign
            string IPv4 = "123.123.123.123/23";
            LeoIPAddress test = new LeoIPAddress(IPv4);

            //Assert
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void IpAdressIsStore()
        {
            //Assign
            string IPv4 = "123.123.123.123/23";
            LeoIPAddress test = new LeoIPAddress(IPv4);

            //Assert
            Assert.AreEqual(IPv4, test.Address());
        }

        [TestMethod]
        public void MethodsCompile()
        {
            //Assign
            string IPv4 = "123.123.123.123/23";
            LeoIPAddress test = new LeoIPAddress(IPv4);


            //Assert
            Assert.IsNotNull(test.Address());
            Assert.IsNotNull(test.SubnetMask());
            Assert.IsNotNull(test.NetworkID());
            Assert.IsNotNull(test.Broadcast());
            Assert.IsNotNull(test.Range());
        }

        [TestMethod]
        public void CompilesCorrectly()
        {
            //Assign
            string IPv4 = "123.123.123.123/23";
            LeoIPAddress test = new LeoIPAddress(IPv4);

            //Act (Or what each method is supposed to be)
            string Address = "123.123.123.123/23";
            string SubnetMask = "0.254.255.255";
            string NetworkID = "0.122.123.123";
            string Broadcast = "255.123.123.123";
            string Range = "0.122.123.123 - 255.123.123.123";

            //Assert
            Assert.AreEqual(Address, test.Address());
            Assert.AreEqual(SubnetMask, test.SubnetMask());
            Assert.AreEqual(NetworkID, test.NetworkID());
            Assert.AreEqual(Broadcast, test.Broadcast());
            Assert.AreEqual(Range, test.Range());
        }

        [TestMethod]
        public void TwoIPAddress_IsSameNetwork()
        {
            //Assign
            string IPv4first = "123.123.123.123/23";
            LeoIPAddress test1 = new LeoIPAddress(IPv4first);
            string IPv4second = "123.123.123.123/23";
            LeoIPAddress test2 = new LeoIPAddress(IPv4second);

            //Assert
            Assert.IsTrue(test1.IsSameNetwork(test2));
            Assert.AreNotEqual(test1, test2);
        }
    }
}