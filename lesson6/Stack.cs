using System;
using System.Collections.Generic;
using System.Text;

namespace lesson6
{
    public class Stack<T>
    {
        Node<T> head;

        public Stack()
        {
            head = null;
        }

        public void push(T item)
        {
            head = new Node<T>(item, head);

        }

        public T pop()
        {
            if (head == null)
                throw new Exception("Stack is empty");
            T item = head._item;
            head = head._next;
            return item;

        }

        public IEnumerable<T> list()
        {
            Node<T> node = head;
            while (node != null)
            {
                yield return node._item;
                node = node._next;

            }
        }

    }
}
