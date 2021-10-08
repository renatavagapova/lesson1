using System;
using System.Diagnostics;

namespace lesson3
{
    class Program
    {
       
        public class PointClass // вариант для ссылочного типа
        {
            public float X;
            public float Y;
        }
        public struct PointStructFloat // вариант для типа float
        {
            public float X;
            public float Y;
        }
        public struct PointStructDouble // вариант для типа double
        {
            public double X;
            public double Y;
        }
        // объявляем массивы с данными
        public static readonly int size = 10000000; // размер массива данных
        public static PointStructFloat[] arrayFloat = new PointStructFloat[size + 1];
        public static PointStructDouble[] arrayDouble = new PointStructDouble[size + 1];
        public static PointClass[] arrauForClass = new PointClass[size + 1];
        public static float PointDistanceOne(ref PointClass A, ref PointClass B) // вариант теста 1
        {
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceTwo(PointStructFloat A, PointStructFloat B) // вариант теста 2
        {
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistanceThree(PointStructDouble A, PointStructDouble B) // вариант теста 3
        {
            double x = A.X - B.X;
            double y = A.Y - B.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceFour(PointStructFloat A, PointStructFloat B) // вариант теста 4
        {
            float x = A.X - B.X;
            float y = A.Y - B.Y;
            return Sqrt((x * x) + (y * y));
        }
        public static float Sqrt(float x)
        {
            float s = ((x / 2) + x / (x / 2));
            for (int i = 0; i < 4; i++)
            {
                s = (s + x / s) / 2;
            }
            return s;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            // заполняем массив случайными данными
            for (int i = 0; i <= size; i++)
            {
                arrayFloat[i].X = (float)rnd.NextDouble();
                arrayFloat[i].Y = (float)rnd.NextDouble();
                arrayDouble[i].X = rnd.NextDouble();
                arrayDouble[i].Y = rnd.NextDouble();
                arrauForClass[i] = new PointClass
                {
                    X = arrayFloat[i].X,
                    Y = arrayFloat[i].Y
                };
            }
            // расчёты для всех 4-х вариантов
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Restart();
            for (int i = 0; i < size; i++)
            {
                _ = PointDistanceOne(ref arrauForClass[i], ref arrauForClass[i + 1]);
            }
            stopWatch.Stop();
            long milisek1 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < size; i++)
            {
                _ = PointDistanceTwo(arrayFloat[i], arrayFloat[i + 1]);
            }
            stopWatch.Stop();
            long milisek2 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < size; i++)
            {
                _ = PointDistanceThree(arrayDouble[i], arrayDouble[i + 1]);
            }
            stopWatch.Stop();
            long milisek3 = stopWatch.ElapsedMilliseconds;
            stopWatch.Restart();
            for (int i = 0; i < size; i++)
            {
                _ = PointDistanceFour(arrayFloat[i], arrayFloat[i + 1]);
            }
            stopWatch.Stop();
            long milisek4 = stopWatch.ElapsedMilliseconds;
            // результаты
            Console.WriteLine(" Тест\t\tвремя");
            Console.WriteLine(" Тест № 1\t" + milisek1.ToString());
            Console.WriteLine(" Тест № 2\t" + milisek2.ToString());
            Console.WriteLine(" Тест № 3\t" + milisek3.ToString());
            Console.WriteLine(" Тест № 4\t" + milisek4.ToString());
           
            
        }
    }
}
