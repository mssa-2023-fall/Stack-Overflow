namespace LearningImmutable
{
    [TestClass]
    public class DirectoryTreeTest
    {
        [TestMethod]
        public void TestValidRoots()
        {
            //Arange
            var builder = new DirectoryTreeBuilder();
            string invalidDirectory = "InvalidDirectory";
            //Assert
            Assert.ThrowsException<DirectoryNotFoundException>(() => builder.BuildTree(invalidDirectory, "Endpoint"));
        }

        [TestMethod]
        public void BuildTreeValidInputs()
        {
            //Arrange
            var builder = new DirectoryTreeBuilder();
            string rootDir = "C:\\MSSA projects";
            string endpoint = "C:\\MSSA projects\\stack-overflow repo\\DSA\\LearningImmutable";
            DirectoryTreeBuilder.TreeNode rootNode = builder.BuildTree(rootDir, endpoint);

            //Assert
            Assert.IsNotNull(rootNode);
            Assert.AreEqual("MSSA projects", rootNode.Name);

            Console.WriteLine(rootNode.Name);
        }
    }
}