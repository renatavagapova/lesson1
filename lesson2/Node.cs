using System;
using static lesson2.Program;

namespace lesson2
{
    public class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node firstNode;//первый(стартовый) элемент
        public Node lastNode;//последний(конечный) элемент
        int count;//кол-во элементов всписке


        public int GetCount() => count;

        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };

            if (firstNode == null)
            {
                firstNode = lastNode = newNode;
            }
            else
            {
                lastNode.NextNode = newNode;
                lastNode = newNode;
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (value > count || value < 0)
                throw new ArgumentOutOfRangeException();
            else
            {
                var next = node.NextNode;
                var newOne = new Node() { Value = value, NextNode = next, PrevNode = node };
                node.NextNode = newOne;
                if (next != null) next.PrevNode = newOne;
                count++;
            }
        }

        private Node GetNodeOnIndex(int index)
        {
            if (IsIndexNotInRange(index)) return null;

            Node needed;

            if (count - 1 / 2 >= index)
            {
                needed = firstNode;
                for (var i = 1; i <= index; i++)
                {
                    needed = needed.NextNode;
                }
            }
            else
            {
                needed = lastNode;
                for (var i = count - 1; i > index; i--)
                {
                    needed = needed.PrevNode;
                }
            }

            return needed;
        }

        public void RemoveNode(int index)
        {
            if (IsIndexNotInRange(index))
                throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                if (firstNode.NextNode is { } node)
                {
                    firstNode = node;
                    node.PrevNode = null;
                }
                else firstNode = lastNode = null;
            }
            else
            {
                var toRemove = GetNodeOnIndex(index);

                if (toRemove.NextNode != null)
                    toRemove.NextNode.PrevNode = toRemove.PrevNode;
                toRemove.PrevNode.NextNode = toRemove.NextNode;
                toRemove.NextNode = toRemove.PrevNode = null;
            }
            count--;
        }



        private bool IsIndexNotInRange(int index) => index < 0 || index >= count;
        public void RemoveNode(Node node)
        {

            if (firstNode == node)
            {
                if (firstNode == lastNode)
                {
                    firstNode = lastNode = null;
                }
                else
                {
                    firstNode = node.NextNode;
                    node.NextNode = null;
                    firstNode.PrevNode = null;
                }
            }
            else
            {
                if (node.NextNode != null)
                    node.NextNode.PrevNode = node.PrevNode;
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode = node.PrevNode = null;
            }

        }


        public Node FindNode(Node node, int searchValue)
        {
            var currentnode = node.firstNode;

            while (currentnode != null)
            {
                if (currentnode.Value == searchValue)
                {
                    return currentnode;
                }
                else
                {
                    currentnode = currentnode.NextNode;
                }
            }
            return null;
        }




    }
}
