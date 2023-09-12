using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoBinaryTree
{
    public class LeoBiTree
    {
        public LeoNode Root { get; set; }
        public void Insert(int value)
        {
            LeoNode newNode = new LeoNode(value);

            if(Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<LeoNode> queue = new Queue<LeoNode>();
            queue.Enqueue(Root);

            while(queue.Count > 0)
            {
                LeoNode current = queue.Dequeue();

                if(current.left == null)
                {
                    current.left = newNode;
                    return;
                } 
                else if(current.right == null)
                {
                    current.right = newNode;
                    return;
                }

                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
        }

        public void PrintTree(LeoNode Node)
        {
            if (Node == null) return;

            //Pre order traversal (Breadth First Search)
            Console.Write(Node.data + " ");
            PrintTree(Node.left);
            PrintTree(Node.right);

            /* (These are two different kinds of depth searches)
            //In order traversal
            PrintTree(Node.left);
            Console.Write(Node.data + " ");
            PrintTree(Node.right);

            //Post order traversal
            PrintTree(Node.left);
            PrintTree(Node.right);
            Console.Write(Node.data + " "); */
        }
    }
}
