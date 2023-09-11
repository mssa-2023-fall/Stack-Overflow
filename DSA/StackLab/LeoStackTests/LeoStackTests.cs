namespace LeoStackTests
{
    [TestClass]
    public class LeoStackLab1Tests
    {
        [TestMethod]
        public void CanItBeInstantiated_LeoStack()
        {
            //Arrange
            LeoStack<int> leoStack = new LeoStack<int>();

            //Act
            leoStack.Push(10);
            leoStack.Push(20);


            //Assert
            Assert.AreEqual(20, leoStack.Pop());
            Assert.AreEqual(10, leoStack.Pop());
            Assert.IsTrue(leoStack.IsEmpty());
        }

        [TestMethod]
        public void PeekTest_LeoStack()
        {
            LeoStack<string> leoS = new LeoStack<string>();

            leoS.Push("Hello");
            leoS.Push("MSSA");

            Assert.AreEqual("MSSA", leoS.Peek());
            Assert.IsFalse(leoS.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PopEmptyStack_LeoStack()
        {
            LeoStack<int> ls = new LeoStack<int>();
            ls.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PeekEmptyStack_LeoStack()
        {
            LeoStack<int> ls = new LeoStack<int>();
            ls.Peek();
        }
    }
}