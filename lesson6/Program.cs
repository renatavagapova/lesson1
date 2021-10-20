using System;
using System.Collections.Generic;

namespace lesson6
{
    class Program
    {
        static Graph graph = new Graph();
        static Dijkstra dijkstra = new Dijkstra(graph);

        static void Main(string[] args)
        {


            graph.AddNode('A');
            graph.AddNode('B');
            graph.AddNode('C');
            graph.AddNode('D');
            graph.AddNode('E');
            graph.AddNode('F');
            graph.AddNode('G');
            graph.AddNode('H');
            graph.AddNode('I');

            graph.AddEdge('A', 'B', new Random().Next(1, 100));
            graph.AddEdge('A', 'C', new Random().Next(1, 100));
            graph.AddEdge('A', 'D', new Random().Next(1, 100));
            graph.AddEdge('B', 'C', new Random().Next(1, 100));
            graph.AddEdge('C', 'D', new Random().Next(1, 100));
            graph.AddEdge('B', 'E', new Random().Next(1, 100));
            graph.AddEdge('C', 'E', new Random().Next(1, 100));
            graph.AddEdge('C', 'F', new Random().Next(1, 100));
            graph.AddEdge('D', 'F', new Random().Next(1, 100));
            graph.AddEdge('E', 'F', new Random().Next(1, 100));
            graph.AddEdge('E', 'G', new Random().Next(1, 100));
            graph.AddEdge('F', 'G', new Random().Next(1, 100));
            graph.AddEdge('C', 'H', new Random().Next(1, 100));
            graph.AddEdge('E', 'H', new Random().Next(1, 100));
            graph.AddEdge('B', 'H', new Random().Next(1, 100));
            graph.AddEdge('D', 'I', new Random().Next(1, 100));
            graph.AddEdge('H', 'I', new Random().Next(1, 100));
            graph.AddEdge('F', 'I', new Random().Next(1, 100));

            Console.WriteLine();

            // алгоритм Дейкстры
            Console.WriteLine(dijkstra.GetShortestPath('A', 'I'));  // Расчет самого быстрый маршрут из 'A' в'I'
            Console.WriteLine();





            #region Вариант 1
            //Graph(10); // количество вершин

            //BFS();

            //Graph(10); // количество вершин

            //DFS();
            #endregion
        }




        static void Test()
        {
            #region Test
            Stack<City> stack = new Stack<City>();



            stack.push(new City("Москва"));
            stack.push(new City("Лондон"));
            stack.push(new City("Нью-Йорк"));

            foreach (City item in stack.list())
                Console.WriteLine(item.Title());

            Console.WriteLine(stack.pop().Title());
            Console.WriteLine(stack.pop().Title());
            Console.WriteLine(stack.pop().Title());

            //stack.push("стул");
            //stack.push("стол");
            //stack.push("ваза");



            //Node node1 = new Node("молоко",null);
            //Node node2 = new Node("хлеб", node1);
            //Node node3 = new Node("мыло", node2);

            //foreach (string item in stack.list())
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(node3);

            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            Console.WriteLine(stack.pop());
            #endregion
        }


        #region Вариант 1
        static Queue<int> queue = new Queue<int>();    // очередь, хранящая номера вершин

        static Random rand = new Random();
        static int visited;
        static bool[] used;
        static int[][] g;

        private static void Graph(int node)
        {
            Console.WriteLine();
            Console.WriteLine(" Построение графа");

            visited = node - 1;

            used = new bool[visited + 1];  //массив отмечающий посещённые вершины
            g = new int[visited + 1][];   //массив содержащий записи смежных вершин

            for (int i = 0; i < visited + 1; i++)
            {
                g[i] = new int[visited + 1];
                Console.Write($"\n({i + 1}) вершина -->[");
                for (int j = 0; j < visited + 1; j++)
                {
                    g[i][j] = rand.Next(0, 2);
                }
                g[i][i] = 0;
                foreach (var item in g[i])
                {
                    Console.Write(" {0}", item);
                }
                Console.Write("]\n");
            }

            used[visited] = true;     //массив, хранящий состояние вершины(посещали мы её или нет)

            queue.Enqueue(visited);
            Console.WriteLine();


        }
        private static void BFS()
        {
            Console.WriteLine("Начинаем обход с {0} вершины", visited + 1);

            while (queue.Count != 0)
            {
                visited = queue.Peek();
                queue.Dequeue();
                Console.WriteLine("Перешли к узлу {0}", visited + 1);

                for (int i = 0; i < g.Length; i++)
                {
                    if (Convert.ToBoolean(g[visited][i]))
                    {
                        if (!used[i])
                        {
                            used[i] = true;
                            queue.Enqueue(i);
                            Console.WriteLine("Добавили в очередь узел {0}", i + 1);
                        }
                    }
                }
            }
        }

        private static void DFS()
        {


        }
        #endregion


    }
}

