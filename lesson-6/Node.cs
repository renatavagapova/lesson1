using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_6
{
    public class Node<T>
    {
        public T _item { get; private set; }


        public Node<T> _next { get; private set; }


        public Node(T item, Node<T> next)
        {
            _item = item;
            _next = next;

        }

        public override string ToString()
        {
            return _item.ToString() + " " + _next?.ToString();
        }
    }
}
