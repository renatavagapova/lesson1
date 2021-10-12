using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lesson4
{
    class Program
    {
        static string[] array;

        static HashSet<string> hashSet = new HashSet<string>();

        static int newLength;

        static Stopwatch sw;

        static int RandomGenerator(int quantity, int length)
        {
            array = new string[quantity];



            for (int i = 0; i < quantity; i++)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[length];
                var random = new Random();

                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                hashSet.Add(finalString);
                //Console.WriteLine(finalString);


            }
            Console.WriteLine($"Количество объектов: {hashSet.Count}");
            Console.WriteLine("Объекты инициализированны");

            return newLength = length;
        }

        static void TestSpeed(int quantityTest)
        {

            Console.WriteLine("**************************Тестирование**************************");

            Console.WriteLine(" array\t  hashSet\t   ");

            for (int i = 0; i < quantityTest; i++)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[newLength];
                var random = new Random();

                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);

                sw = new Stopwatch();
                sw.Start();

                for (int k = 0; k < array.Length; k++)
                {
                    if (finalString == k.ToString())
                    {
                        Console.WriteLine("НАШЁЛ");
                        break;

                    }

                }
                sw.Stop();
                Console.Write($" {sw.ElapsedTicks}\t");

                sw.Start();

                for (int k = 0; k < hashSet.Count; k++)
                {
                    if (finalString == k.ToString())
                    {
                        Console.WriteLine("НАШЁЛ");
                        break;

                    }

                }
                sw.Stop();
                Console.Write($" {sw.ElapsedTicks}\t\t");

                Console.WriteLine("НЕ НАШЁЛ");
            }

        }

        //---------------------------------ЗАДАНИЕ 2--------------------------------------

        public static Node<int> Insert(Node<int> head, int value)
        {
            Node<int> tmp = null;
            if (head == null)
            {
                head = GetFreeNode(value, null);
                return head;
            }

            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Data)
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else if (value < tmp.Data)
                {
                    if (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else
                {
                    throw new Exception("Дерево построено неправильно");
                }
            }
            return head;
        }

        private static Node<int> GetFreeNode(int value, Node<int> tmp)
        {
            counter++;

            var nl = counter / 2;
            var nr = counter - nl - 1;
            tmp = new Node<int> { Data = value };

            tmp.Left = Tree(nl);
            tmp.Right = Tree(nr);

            return tmp;
        }

        static int counter;

        public static Node<int> Tree(int n)
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
                newNode.Left = Tree(nl);
                newNode.Right = Tree(nr);
            }
            return newNode;
        }
        static public void PreOrderTravers(Node<int> root, string tr = " ")
        {
            if (root != null)
            {
                Console.WriteLine("{1} {0}", root.Data, tr);
                PreOrderTravers(root.Left, $"{tr}{new string(' ', 3)}");
                PreOrderTravers(root.Right, $"{tr}{new string(' ', 3)}");
            }
        }

        static void Main(string[] args)
        {

            // 1
            Console.WriteLine("Задание 1");
            RandomGenerator(100_000, 1_000);       //кол-во строк , длина строки

            TestSpeed(20);                      // кол-во тестов

            Console.WriteLine(new string('*', 65));

            //2
            Console.WriteLine("Задание 2");
            var forest = Tree(20);
            PreOrderTravers(forest);

        }
    }
}
