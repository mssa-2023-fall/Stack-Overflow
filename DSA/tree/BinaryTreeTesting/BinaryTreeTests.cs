namespace BinaryTreeTesting
{
    [TestClass]
    public class BinaryTreeTesting
    {
        [TestMethod]
        public void Instantiation_LeoBinaryTree()
        {
            //Arrange
            LeoBiTree leoTree = new LeoBiTree();

            //Assert
            Assert.IsNotNull(leoTree);
            Assert.IsNull(leoTree.Root);
        }

        [TestMethod]
        public void RootEvalAndInserting_LeoBinaryTree()
        {
            //Arrange
            LeoBiTree leoTree = new LeoBiTree();

            //Act
            leoTree.Insert(1);
            leoTree.Insert(2);
            leoTree.Insert(3);

            //Assert
            Assert.AreEqual(1, leoTree.Root.data);
            Assert.IsNotNull(leoTree.Root.left);
            Assert.IsNotNull(leoTree.Root.right);
        }


            [TestMethod]
        public void BreadthFirstOutput_LeoBinaryTree()
        {
            //Arrange
            LeoBiTree leoTree = new LeoBiTree();

            //Act
            leoTree.Insert(1);
            leoTree.Insert(2);
            leoTree.Insert(3);
            leoTree.Insert(4);
            leoTree.Insert(5);

            //Assert
            string expected = "1 2 4 5 3 ";
            using(ConsoleOutput output = new ConsoleOutput())
            {
                leoTree.traverseTree(leoTree.Root);
                Assert.AreEqual(expected, output.GetOutput());
            }
        }
    }

    //Helper class used for Console output testing
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter sw;
        private readonly TextWriter output;

        public ConsoleOutput()
        {
            sw = new StringWriter();
            output = Console.Out;
            Console.SetOut(sw);
        }

        public string GetOutput()
        {
            return sw.ToString();
        }

        public void Dispose()
        {
            sw.Dispose();
            Console.SetOut(output);
        }
    }
}