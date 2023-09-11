using System;

namespace LeoStack
{
    public class LeoStack<T>
    {
        private LeoNode<T> top;

        public bool IsEmpty()
        {
            return top == null;
        }

        public void Push(T value)
        {
            LeoNode<T> newNode = new LeoNode<T>(value);
            newNode.Next = top;
            top = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty");
            }

            T value = top.Value;
            top = top.Next;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            return top.Value;
        }
    }
}