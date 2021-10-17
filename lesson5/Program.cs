using System;
using System.Collections.Generic;

namespace lesson5
{
    class Program
    {
       
            static public void PreOrderTravers(Node<int> root, string tr = " ")
            {
                if (root != null)
                {
                    Console.WriteLine("{1} {0}", root.Data, tr);
                    PreOrderTravers(root.Left, $"{tr}{new string(' ', 3)}");
                    PreOrderTravers(root.Right, $"{tr}{new string(' ', 3)}");
                }
            }


            public static Node<int> Elements(int n)
            {
                //counter ++;

                Node<int> newNode = null;
                if (n == 0)
                    return null;
                else
                {
                    var nl = n / 2;
                    var nr = n - nl - 1;
                    newNode = new Node<int>();
                    newNode.Data = new Random().Next(0, 100);
                    newNode.Left = Elements(nl);
                    newNode.Right = Elements(nr);
                }
                return newNode;
            }

            private static void BFS(Node<int> tree)
            {
                Queue<Node<int>> bfs = new Queue<Node<int>>();

                bfs.Enqueue(tree);

                while (bfs.Count > 0)
                {
                    tree = bfs.Dequeue();
                    Console.Write(tree.Data + "  ");

                    if (tree.Left != null)
                        bfs.Enqueue(tree.Left);

                    if (tree.Right != null)
                        bfs.Enqueue(tree.Right);
                }
                Console.WriteLine();
            }
            private static void DFS(Node<int> tree)
            {
                if (tree == null)
                    return;

                Console.Write(tree.Data + "  ");
                DFS(tree.Left);
                DFS(tree.Right);
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Сбалансированное дерево");
                var tree = Elements(20);
                PreOrderTravers(tree);
                Console.WriteLine(new string('*', 50));
                Console.WriteLine("Реализация breadth-first search - BFS");     //      поиск в ширину, очередь — это FIFO-структура данных
                BFS(tree);
                Console.WriteLine("Реализация deep-first search - DFS");     //      поиск в глубину, стек — это LIFO-структура данных
                DFS(tree);
                Console.WriteLine();

            }
    }
}
