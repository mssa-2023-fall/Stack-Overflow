namespace MssaExtensionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            //Assign
            var _file = new FileInfo(@"C:\test\oscar_age_male.csv");

            //Act
            string base64 = _file.GetSHAString(StringFormat.Base64);
            string hex = _file.GetSHAString(StringFormat.Hex);

            //Assert
            Assert.AreEqual("4r7YHwqBQPs26FCqZI+pKwYoQWQ=", base64);
            Assert.AreEqual("E2BED81F0A8140FB36E850AA648FA92B06284164", hex);
        }

        [TestMethod]
        public void TestLinq_Median()
        {
            //Assign
            IEnumerable<int> input1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<int> input2 = new[] { 1, 2, 3, 4, 5, 6, 7, 8};
            
            //Act
            var median1 = input1.Median();
            var median2 = input2.Median();

            //Assert
            Assert.AreEqual(4, median1);
            Assert.AreEqual(5, median2);
        }

        [TestMethod]
        public void CustomLinqMethods()
        {
            IEnumerable<int> inputs1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(4, median);
        }
        [TestMethod]
        public void CustomLinqMethods2()
        {
            IEnumerable<double> inputs1 = new[] { 1, 2.5, 3.9, 4.7, 5.2, 6.7, 7.5, 8.9 };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2, median);
        }
        [TestMethod]
        public void CustomLinqMethods3()
        {
            IEnumerable<float> inputs1 = new[] { 1f, 2.5f, 3.9f, 4.7f, 5.2f, 6.7f, 7.5f, 8.9f };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2f, median);
        }
        [TestMethod]
        public void CustomLinqMethods4()
        {
            IEnumerable<decimal> inputs1 = new[] { 1m, 2.5m, 3.9m, 4.7m, 5.2m, 6.7m, 7.5m, 8.9m };
            var median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(5.2m, median);
        }



    }
}