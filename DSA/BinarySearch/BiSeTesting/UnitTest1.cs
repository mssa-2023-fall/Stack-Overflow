namespace BiSeTesting
{
    [TestClass]
    public class BinarySeachTesting
    {
        [TestMethod]
        public void TypesOfExceptions_LeoBinarySearch()
        {
            //Assign
            int[] emptyTest = new int[0];
            int[] outOfOrder = { 4, 1, 5, 9, 2 };

            //Assert
            Assert.ThrowsException<Exception>(() => LeoSearch.BinarySearch(emptyTest, 2));
            Assert.ThrowsException<Exception>(() => LeoSearch.BinarySearch(outOfOrder, 2));
        }

        [TestMethod]
        public void CorrectResponse_LeoBinarySearch()
        {
            //Assign
            int[] test = new int[1000];

            //Act
            for(int i = 0; i < test.Length; i++)
            {
                test[i] = i;
            }
            int result = LeoSearch.BinarySearch(test, 847);

            //Assert
            Assert.AreEqual(847, result);
            Assert.IsNotNull(result);
        }
    }
}