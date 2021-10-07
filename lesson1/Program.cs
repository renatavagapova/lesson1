using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson1
{
    class Program
    {
        //Задание 1
        //проверка числа на прсототу согласно блок-схеме
        static int IsSimple(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
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
        public class TestCase
        {
            public int X { get; set; }
            public string Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        static void TestIsSimple(TestCase testCase)
        {
            try
            {
                var actual = IsSimple(testCase.X);
                var a = Convert.ToString(actual);

                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }

            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }


        }

        ////Задание 2
        ////Сложность функции равна O(N^3)
        //public static int StrangeSum(int[] inputArray)
        //{
        //    int sum = 0;                                              //o(1)
        //    for (int i = 0; i < inputArray.Length; i++)               //O(n)
        //    {
        //        for (int j = 0; j < inputArray.Length; j++)           //O(n)
        //        {
        //            for (int k = 0; k < inputArray.Length; k++)       //O(n)
        //            {
        //                int y = 0;

        //                if (j != 0)
        //                {
        //                    y = k / j;                                //O(1)
        //                }

        //                sum += inputArray[i] + i + k + j + y;         //O(1)
        //            }
        //        }
        //    }

        //    return sum;                                               //O(1)
        //}

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


        ////Вычисление числа Фибоначчи с помощью цикла
        //public static int FibonacciByCicl(int n)
        //{
        //    if (n == 0)
        //    {
        //        return 0;
        //    }
        //    if (n == 1)
        //    {
        //        return 1;
        //    }
        //    var prev = 0;
        //    var cur = 1;
        //    for (var i = 2; i <= n; i++)
        //    {
        //        var temp = prev + cur;
        //        prev = cur;
        //        cur = temp;
        //    }
        //    return cur;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            //Console.WriteLine("Введите число");
            //int n = int.Parse(Console.ReadLine());
            //IsSimple(n);
            //Console.WriteLine();
            var testCase1 = new TestCase()
            {
                X = 5,
                Expected = 5,
                ExpectedException = null
            };
            TestIsSimple(testCase1);


            //Console.WriteLine("Задание 3");
            //Console.WriteLine("Ряд Фибоначчи, вычесленный с помощью рекурсии \nВведите число, до которого будет считаться ряд Фибоначчи ");
            //int number = int.Parse(Console.ReadLine());
            //for (int i = 0; i <= number; i++)
            //{
            //    Console.Write(FibonacciRecurs(i) + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine("Ряд Фибоначчи, вычесленный с помощью циклов \nВведите число, до которого будет считаться ряд Фибоначчи ");
            //int number1 = int.Parse(Console.ReadLine());
            //for (int i = 0; i <= number1; i++)
            //{
            //    Console.Write(FibonacciByCicl(i) + " ");
            //}
            //Console.ReadKey();
        }
        //public class TestCase
        //{
        //    public int X { get; set; }
        //    public int Y { get; set; }
        //    public int Expected { get; set; }
        //    public Exception ExpectedException { get; set; }
        //}

        //static int SumPositive(int x, int y)
        //{
        //    if (x < 0 || y < 0)
        //    {
        //        throw new ArgumentException("x and y must be positive");
        //    }

        //    return x + y;
        //}

        //static void TestSum(TestCase testCase)
        //{
        //    try
        //    {
        //        var actual = SumPositive(testCase.X, testCase.Y);

        //        if (actual == testCase.Expected)
        //        {
        //            Console.WriteLine("VALID TEST");
        //        }
        //        else
        //        {
        //            Console.WriteLine("INVALID TEST");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (testCase.ExpectedException != null)
        //        {
        //            //TODO add type exception tests;
        //            Console.WriteLine("VALID TEST");
        //        }
        //        else
        //        {
        //            Console.WriteLine("INVALID TEST");
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    var testCase1 = new TestCase()
        //    {
        //        X = 6,
        //        Y = 4,
        //        Expected = 10,
        //        ExpectedException = null
        //    };

        //    var testCase2 = new TestCase()
        //    {
        //        X = 1,
        //        Y = 4,
        //        Expected = 5,
        //        ExpectedException = null
        //    };

        //    TestSum(testCase1);
        //    TestSum(testCase2);
        //}
    }
}
