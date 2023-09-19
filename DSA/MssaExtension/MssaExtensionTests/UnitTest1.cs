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
            Assert.AreEqual(5.5, median2);
        }
    }
}