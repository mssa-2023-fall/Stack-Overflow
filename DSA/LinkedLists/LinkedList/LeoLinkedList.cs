using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LeoLinkedList<T> : ILinkedList<T>
    {
        private LeoNode<T>? head;
        private LeoNode<T>? tail;
        public int Count { get; private set; } = 0;

        public void AddFirst(INode<T> value)
        {
            LeoNode<T> newNode = (LeoNode<T>)value;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.NextNode = head;
                head = newNode;
            }

            Count++;
        }

        public void InsertAfterNodeIndex(INode<T> value, int position)
        {
            LeoNode<T> newNode = (LeoNode<T>)value;

            if (position < 0 || position >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (position == Count - 1)
            {
                AddLast(newNode);
                return;
            }

            LeoNode<T>? current = head;

            for (int i = 0; i < position; i++)
            {
                current = current.NextNode;
            }

            newNode.NextNode = current.NextNode;
            current.NextNode = newNode;
            Count++;
        }

        public void AddLast(INode<T> value)
        {
            LeoNode<T> newNode = (LeoNode<T>)value;

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.NextNode = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            head = head.NextNode;

            if (head == null)
            {
                tail = null;
            }

            Count--;
        }

        public void RemoveAt(int IndexPosition)
        {
            if (Count == 0 || Head == null) throw new InvalidOperationException();
            

            if (IndexPosition == 0)
            {
                RemoveFirst();
                return;
            }

            LeoNode<T>? current = head;

            for (int i = 0; i < IndexPosition - 1; i++)
            {
                current = current.NextNode;
            }

            current.NextNode = current.NextNode.NextNode;

            if (current.NextNode == null)
            {
                tail = current;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException("The linked list is empty.");
            }

            if (head == tail)
            {
                Clear();
                return;
            }

            LeoNode<T>? current = head;

            while (current.NextNode != tail)
            {
                current = current.NextNode;
            }
            current.NextNode = null;
            tail = current;
            Count--;
        }

        public INode<T> FindFirst(T value)
        {
            foreach (var node in Nodes)
            {
                if (node.Content.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        public INode<T>[] FindAll(T value)
        {
            List<INode<T>> foundNodes = new List<INode<T>>();

            foreach (var node in Nodes)
            {
                if (node.Content.Equals(value))
                {
                    foundNodes.Add(node);
                }
            }
            return foundNodes.ToArray();
        }
        public INode<T> Head => head;

        public INode<T> Tail => tail;

        public IEnumerable<INode<T>> Nodes
        {
            get
            {
                LeoNode<T>? current = head;
                while (current != null)
                {
                    yield return current;
                    current = current.NextNode;
                }
            }
        }
    }
        public class LeoNode<U> : INode<U>
        {
            public U Content { get; set; }
            public LeoNode<U>? NextNode { get; set; }
            public LeoNode(U content)
            {
                Content = content;
            }

            public INode<U>? Next()
            {
                return NextNode;
            }
        }
    
}
