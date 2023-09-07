using LinkedList;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LeoLinkedListConstructor()
        {
            var testLL = new LeoLinkedList<int>();
            Assert.AreEqual(0, testLL.Count);
            Assert.IsNull(testLL.Head);
            Assert.IsNull(testLL.Tail);
        }

        [TestMethod]
        public void EmptyCallsThrowExceptions()
        {
            //Arrange
            var leoLL = new LeoLinkedList<int>();

            //No Act


            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveLast(), "RemoveLast method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveFirst(), "RemoveFirst method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveAt(0), "RemoveAt method on empty list did not throw an exception");
            Assert.ThrowsException<IndexOutOfRangeException>(() => leoLL.InsertAfterNodeIndex(new LeoNode<int>(4), 2), "InsertAfterNodeIndex method on empty list did not throw an exception");
        }

        [TestMethod]
        public void AddFirstToEmptyList()
        {
            //Arrange
            var testLL = new LeoLinkedList<int>();

            //Act
            testLL.AddFirst(new LeoNode<int>(10));

            //Assert
            Assert.AreEqual(1, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.AreEqual(10, testLL.Head.Content);
        }

        [TestMethod]
        public void InsertAfterNodeTest()
        {
            //Arrange
            var initialNode = new LeoNode<int>(4);
            var leoLL = new LeoLinkedList<int>();
            //Arrange (part of set up not what we are testing)
            leoLL.AddFirst(initialNode);
            leoLL.AddFirst( new LeoNode<int>(3));

            //Act (This is what we are looking into)
            leoLL.InsertAfterNodeIndex(new LeoNode<int>(5), 0);

            //Assert
            Assert.AreEqual(3, leoLL.Count);
            Assert.IsNotNull(leoLL.Head);
            Assert.AreEqual(3, leoLL.Head.Content);
            Assert.AreEqual(5, leoLL.Head?.Next()?.Content);
            Assert.AreEqual(4, leoLL.Head?.Next()?.Next()?.Content);
        }

        [TestMethod]
        public void AddLast_ChecksBothEmptyAndPreloadedList()
        {
            //Arrange
            var leoLL = new LeoLinkedList<int>();

            //Act
            leoLL.AddLast(new LeoNode<int>(5));
            leoLL.AddLast(new LeoNode<int>(66));

            //Assert
            Assert.IsNotNull(leoLL.Head);
            Assert.IsNotNull(leoLL.Tail);
            Assert.AreEqual(2, leoLL.Count);
            Assert.AreEqual(5, leoLL.Head.Content);
            Assert.AreEqual(66, leoLL.Head?.Next()?.Content);
            Assert.AreEqual(66, leoLL.Tail.Content);
        }

        [TestMethod]
        public void ClearMethodTesting()
        {
            //Arrange
            var leoLL = new LeoLinkedList<int>();
            leoLL.AddFirst(new LeoNode<int>(7));
            leoLL.AddFirst(new LeoNode<int>(1));
            leoLL.AddFirst(new LeoNode<int>(3));

            //Act
            leoLL.Clear();

            //Assert
            Assert.IsNull(leoLL.Head);
            Assert.IsNull(leoLL.Tail);
            Assert.AreEqual(0, leoLL.Count);
        }
    }
}