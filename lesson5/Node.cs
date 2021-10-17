using System;
using System.Collections.Generic;
using System.Text;

namespace lesson5
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;

        }

        public Node() { }

        public Node(T data)
        {
            Data = data;
        }
    }
}
