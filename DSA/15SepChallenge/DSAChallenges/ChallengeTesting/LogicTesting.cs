

namespace ChallengeTesting
{
    [TestClass]
    public class FirdayChallenge
    {
        Sort logic = new Sort();
        [TestMethod]
        public void GeneratesArray()
        {
            //Assign
            var randomArray = logic.RandomNumArr(1000);

            //Assert
            Assert.IsNotNull(randomArray);
            Assert.AreEqual(1000, randomArray.Length);
        }

        [TestMethod]
        public void IsSortedWorks()
        {
            //Assign
            int[] numArr = { 5, 3, 1, 2, 4, 7, 6, 8, 10, 9 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Act
            numArr = logic.SortArr(numArr);

            for(int i = 0; i < numArr.Length - 1; i++)
            {

            //Assert
                Assert.AreEqual(expected[i], numArr[i]);
            }
            Assert.AreEqual(10, numArr.Length);
            Assert.IsTrue(numArr[0] < numArr[numArr.Length - 1]);
        }
        [TestMethod]
        public void ReverseWorks()
        {
            //Assign
            int[] numArr = { 5, 3, 1, 2, 4, 7, 6, 8, 10, 9 };
            int[] expected = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            //Act
            numArr = logic.SortArr(numArr, false); //bool represents if it is in asc

            for (int i = 0; i < numArr.Length - 1; i++)
            {

                //Assert
                Assert.AreEqual(expected[i], numArr[i]);
            }
            Assert.AreEqual(10, numArr.Length);
            Assert.IsTrue(numArr[0] > numArr[numArr.Length - 1]);
        }

        [TestMethod]
        public void BinarySearchReturnsIndex()
        {
            //Assign 
            int[] numArr = { 5, 3, 1, 2, 8, 10, 9 };
            int target = 8;
            int index = 0;

            //Act
            numArr = logic.SortArr(numArr);
            index = logic.BinaryTreeBreathSearch(numArr, target);

            //Assert
            Assert.AreEqual(4, index);
        }
        [TestMethod]
        public void BinarySearchReturnsFalse_IfInvalid()
        {
            //Assign 
            int[] numArr = { 5, 3, 1, 2, 8, 10, 9 };
            int target = 4;

            //Act
            numArr = logic.SortArr(numArr);
            bool isFound = logic.IsPresent(numArr, target);

            //Assert
            Assert.IsFalse(isFound);
        }
    }
}