using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_6
{
    public struct NodeEdge
    {
        public char node;
        public int weight;

        public NodeEdge(char node, int weight)
        {
            this.node = node;
            this.weight = weight;

        }
    }

    public struct GraphNode
    {
        public char node;
        //public Stack<char> edges;

        public Stack<NodeEdge> edges;

        public GraphNode(char node)
        {
            this.node = node;
            //edges = new Stack<char>();
            edges = new Stack<NodeEdge>();

        }

    }

    public class Graph
    {
        Stack<GraphNode> nodes;
        public Graph()
        {
            nodes = new Stack<GraphNode>();
        }

        public void AddNode(char node)
        {
            GraphNode graphNode = new GraphNode(node);

            nodes.push(graphNode);
        }

        public void AddEdge(char node1, char node2, int weight)
        {
            //GetNode(node1).edges.push(node2);
            //GetNode(node2).edges.push(node1);

            GetNode(node1).edges.push(new NodeEdge(node2, weight));
            GetNode(node2).edges.push(new NodeEdge(node1, weight));

            Console.WriteLine($"Вершина-{node1} Ребро-{weight} Вершина-{node2}");
        }

        public IEnumerable<char> GetNodes()
        {
            foreach (GraphNode graphNode in nodes.list())
                yield return graphNode.node;
        }

        public GraphNode GetNode(char node)
        {
            foreach (GraphNode graphNode in nodes.list())
                if (graphNode.node == node)
                    return graphNode;

            throw new Exception("Node not found");
        }

    }
}