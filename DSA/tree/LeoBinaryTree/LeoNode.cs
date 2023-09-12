namespace LeoBinaryTree
{
    public class LeoNode
    {
        public LeoNode left { get; set; }
        public LeoNode right { get; set; }
        public int data { get; set; }

        public LeoNode(int data)
        {
            this.data = data;
            this.left = null;
            this.right = null;
        }
    }
}