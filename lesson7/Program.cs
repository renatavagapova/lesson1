using System;
using System.Collections.Generic;

namespace lesson7
{
    class Program
    {
        const int N = 3;
        const int M = 3;

        static int k = 0;

        const int X = 8;
        const int Y = 8;
        static int[,] board = new int[X, Y];

        static void Print2(int n, int m, int[,] a)
        {

            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\r\n");
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine(lcsLength2(  //нахождение наибольшей общей подпоследовательности
                "11528974",
                "15921697"
                ));
            Console.WriteLine(k);

            Chess();    //Расстановка 8 ферзей на шахматном поле так, чтобы они не били друг друга


            //Way1();

            //Way2();
        }

        static void Way1()
        {
            int[] a = { 1, 1, 5, 2, 8, 9, 7, 4 };
            int[] b = { 1, 5, 9, 2, 1, 6, 9, 7 };

            var result = new List<int> { };

            int lastIndexB = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = lastIndexB; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        result.Add(b[j]);
                        lastIndexB = j + 1;
                        break;

                    }

                }

            }
            Console.WriteLine(string.Join(", ", result));

        }

        static void Way2()
        {
            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            Print2(N, M, A);

        }

        static int lcsLength(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0)
                return 0;
            else if (a[0] == b[0])
                return 1 + lcsLength(a.Substring(1), b.Substring(1));
            else
                return Math.Max(lcsLength(a.Substring(1), b), lcsLength(a, b.Substring(1)));
        }

        static int lcsLength2(string a, string b, int i = 0, int j = 0)
        {
            k++;

            if (a.Length == 0 || b.Length == 0
                || i >= a.Length || j >= b.Length)
                return 0;
            else if (a[i] == b[j])
                return 1 + lcsLength2(a, b, i + 1, j + 1);
            else
                return Math.Max(lcsLength2(a, b, i + 1, j), lcsLength2(a, b, i, j + 1));


        }

        static void Chess()
        {
            Zero(X, Y, board);
            SearchSolution(1);
            Console.WriteLine(" ");
            Print(X, Y, board);
        }

        static bool SearchSolution(int n)
        {
            // Если проверка доски возвращает 0, то эта расстановка не подходит
            if (CheckBoard() == 0) return false;
            // 9 ферзя не ставим. Решение найдено
            if (n == 9) return true;
            int row;
            int col;
            for (row = 0; row < X; row++)
                for (col = 0; col < Y; col++)
                {
                    if (board[row, col] == 0)
                    {
                        // Расширяем test_solution
                        board[row, col] = n;
                        // Рекурсивно проверяем, ведёт ли это к решению.
                        if (SearchSolution(n + 1)) return true;
                        // Если мы дошли до этой строки, данное частичное решение
                        // не приводит к полному
                        board[row, col] = 0;
                    }
                }
            return false;
        }

        // Проверка всей доски
        static int CheckBoard()
        {
            int i, j;
            for (i = 0; i < X; i++)
                for (j = 0; j < Y; j++)
                    if (board[i, j] != 0)
                        if (CheckQueen(i, j) == 0)
                            return 0;
            return 1;
        }

        // Проверка определённого ферзя
        static int CheckQueen(int x, int y)
        {
            for (int i = 0; i < X; i++)
                for (int j = 0; j < Y; j++)
                    // Если нашли фигуру
                    if (board[i, j] != 0)
                        if (!(i == x && j == y)) // Если это не наша фигура
                        {
                            // Лежат на одной вертикали или горизонтали
                            if ((i - x) == 0 || (j - y) == 0)
                                return 0;
                            // Лежат на одной диагонали
                            if (Math.Abs(i - x) == Math.Abs(j - y))
                                return 0;
                        }

            // Если мы дошли до этого места, то всё в порядке
            return 1;
        }

        // Выводим доску на экран
        static void Print(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\n");
            }
        }

        // Очищаем доску
        static void Zero(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                    a[i, j] = 0;
        }


    }
}
