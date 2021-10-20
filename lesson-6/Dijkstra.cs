using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_6
{
    public class NodeInfo
    {
        public char node;
        public bool used;
        public int sum;
        public char prev;

        public NodeInfo(char node)
        {
            this.node = node;
            used = false;
            sum = int.MaxValue;
            prev = node;

        }

    }

    class Dijkstra
    {
        private Graph graph;

        private Stack<NodeInfo> info;

        public Dijkstra(Graph graph)
        {

            this.graph = graph;
        }

        public string GetShortestPath(char node1, char node2)
        {
            Init();
            GetNodeInfo(node1).sum = 0;

            char curr;
            while ((curr = FindUnusedMinimalNode()) != '0')
            {
                SetSumToNextNodes(curr);
            }

            Console.WriteLine();
            Console.Write("Самый быстрый маршрут из 'A' в'I'= ");

            return RestorePath(node1, node2);
        }

        private string RestorePath(char node1, char node2)
        {
            string path = node2.ToString();

            while (node2 != node1)
            {

                node2 = GetNodeInfo(node2).prev;
                path = node2.ToString() + path;
            }
            return path;
        }

        private void SetSumToNextNodes(char curr)
        {
            NodeInfo currInfo = GetNodeInfo(curr);
            currInfo.used = true;
            foreach (var next in graph.GetNode(curr).edges.list())
            {
                int newSum = currInfo.sum + next.weight;
                NodeInfo nextInfo = GetNodeInfo(next.node);
                if (newSum < nextInfo.sum)
                {
                    nextInfo.sum = newSum;
                    nextInfo.prev = curr;

                }
            }
        }


        private char FindUnusedMinimalNode()
        {
            int minSum = int.MaxValue;
            char minNode = '0';
            Console.Write('A');
            foreach (var node in graph.GetNodes())
            {

                NodeInfo info = GetNodeInfo(node);
                Console.Write($"{node}  ");
                if (info.used) continue;
                if (info.sum < minSum)
                {
                    minSum = info.sum;


                    minNode = node;
                    Console.Write($"={minSum} {minNode} ");
                }
            }
            Console.WriteLine();

            return minNode;
        }

        private void Init()
        {
            info = new Stack<NodeInfo>();

            foreach (var node in graph.GetNodes())
                info.push(new NodeInfo(node));


        }

        private NodeInfo GetNodeInfo(char node)
        {
            foreach (NodeInfo info in info.list())
                if (info.node == node)
                    return info;

            throw new Exception("Node not found");

        }

    }
}
