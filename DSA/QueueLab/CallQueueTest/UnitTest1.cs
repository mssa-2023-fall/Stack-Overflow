using Microsoft.VisualStudio.TestPlatform.TestHost;
using LeoQueue;

namespace CallQueueTest
{
    [TestClass]
    public class CallQueueTests
    {
        [TestMethod]
        public void EnqueueCallerIds_Pass()
        {
            //Arrange
            leoProgram p = new leoProgram();
            Queue<int> callerIds = new Queue<int>();

            //Act
            callerIds.Enqueue(101);
            callerIds.Enqueue(102);

            //Assert
            Assert.AreEqual(2, callerIds.Count());
        }

        [TestMethod]
        public void IterateQueue_Pass()
        {
            //Arrange
            leoProgram p = new leoProgram();
            Queue<int> callerIds = new Queue<int>();
            callerIds.Enqueue(101);
            callerIds.Enqueue(102);

            //Act
            string result = p.IterateQueue(callerIds);


            //Assert
            Assert.AreEqual(2, callerIds.Count());
        }
    }
}