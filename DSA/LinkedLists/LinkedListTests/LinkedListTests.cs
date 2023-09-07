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
            var leoLL = new LeoLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveLast(), "RemoveLast method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveFirst(), "RemoveFirst method on empty list did not throw an exception");
            Assert.ThrowsException<InvalidOperationException>(() => leoLL.RemoveAt(0), "RemoveAt method on empty list did not throw an exception");
        }

        [TestMethod]
        public void AddFirstToEmptyList()
        {
            var testLL = new LeoLinkedList<int>();

            testLL.AddFirst(new LeoNode<int>(10));

            Assert.AreEqual(1, testLL.Count);
            Assert.IsNotNull(testLL.Head);
            Assert.AreEqual(10, testLL.Head.Content);
        }
    }
}