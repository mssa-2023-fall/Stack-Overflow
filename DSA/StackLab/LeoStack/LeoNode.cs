using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LeoNode<T>
{
    public T Value { get; set; }
    public LeoNode<T> Next { get; set; }

    public LeoNode(T value)
    {
        Value = value;
        Next = null;
    }
}