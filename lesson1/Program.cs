using System;

namespace lesson1
{
    class Program
    {
        //Задание 1
        //проверка числа на прсототу согласно блок-схеме
        static int Simple (int n)
        {
            int d = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;

                }
                else
                {
                    i++;
                }

            }
            if (d == 0)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число не простое");
            }
            return n;

        }
        

        //Задание 2
        //Сложность функции равна O(N^3)
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                              //О(1)
            for (int i = 0; i < inputArray.Length; i++)               //O(n)
            {
                for (int j = 0; j < inputArray.Length; j++)           //O(n)
                {
                    for (int k = 0; k < inputArray.Length; k++)       //O(n)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;                                //O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;         //O(1)
                    }
                }
            }

            return sum;                                               //O(1)
        }

        //Задание 3
        //Вычисление чисел Фибоначчи рекурсивно
        public static int FibonacciRecurs(int a)
        {
            if (a == 0 || a == 1)
            {
                return a;
            }
            else
            {
                return FibonacciRecurs(a - 1) + FibonacciRecurs(a - 2);
            }
        }

        //Вычисление числа Фибоначчи с помощью цикла
        public static int FibonacciByCicl(int n)
        {
            if (n==0)
            {
                return 0;
            }
            if (n==1)
            {
                return 1;
            }
            var prev = 0;
            var cur = 1;
            for (var i = 2; i <= n; i++) 
            {
                var temp = prev + cur;
                prev = cur;
                cur = temp;
            }
            return cur;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int n = int.Parse(Console.ReadLine());
            Simple(n);

            Console.WriteLine("Введите число, до которого будет считаться ряд Фибоначчи ");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= number; i++)
            {
                Console.Write(FibonacciRecurs(i) + " ");
            }
            Console.ReadKey();
            //нужно еще организовать вывод для Фибоначчи с помощью цикла и пересмотреть первую задачу.
        }
    }
}
