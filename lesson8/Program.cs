using System;
using System.Collections.Generic;

namespace lesson8
{
    class Program
    {
        static int[] sort;

        static int[] RandomItem()
        {
            Random random = new Random();
            sort = new int[random.Next(10, 20)];
            for (int i = 0; i < sort.Length; i++)
            {
                sort[i] = random.Next(10, 100);
            }
            return sort;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var arr = RandomItem();

            foreach (var item in arr)
            {
                Console.Write("  " + item);
            }
            Console.WriteLine();

            QuickSort(arr, 0, arr.Length - 1);

            foreach (var item in arr)
            {
                Console.Write("  " + item);
            }
            Console.WriteLine();

            HeapSort(arr, arr.Length - 1);

            foreach (var item in arr)
            {
                Console.Write("  " + item);
            }
            Console.WriteLine();

            Heapify(arr, 0, arr.Length - 1);

            foreach (var item in arr)
            {
                Console.Write("  " + item);
            }
            Console.WriteLine();

            BucketSort(arr);

            foreach (var item in arr)
            {
                Console.Write("  " + item);
            }
            Console.WriteLine();
        }

        static void QuickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];

            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                QuickSort(array, i, last);
            if (first < j)
                QuickSort(array, first, j);
        }

        static void HeapSort(int[] array, int n) //основной метод
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;

            if (left < n && array[left] > array[largest])
                largest = left;

            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, n, largest);
            }
        }

        static void BucketSort(int[] a)
        {
            List<int>[] aux = new List<int>[a.Length];   // массив корзин
            for (int i = 0; i < aux.Length; ++i)        // каждую корзину проинициализировать
                aux[i] = new List<int>();

            int minValue = a[0];
            int maxValue = a[0];

            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i] < minValue)
                    minValue = a[i];
                else if (a[i] > maxValue)
                    maxValue = a[i];
            }

            double numRange = maxValue - minValue;

            for (int i = 0; i < a.Length; ++i)
            {
                // вычисление индекса корзины
                int bcktIdx = (int)Math.Floor((a[i] - minValue) / numRange * (aux.Length - 1));


                aux[bcktIdx].Add(a[i]);
            }

            // сортировка корзин. Здесь я, для упрощения себе писанины, использую библиотечную сортировку
            for (int i = 0; i < aux.Length; ++i)
                aux[i].Sort();

            // собираем отсортированные элементы обратно в массив-источник
            int idx = 0;

            for (int i = 0; i < aux.Length; ++i)
            {
                for (int j = 0; j < aux[i].Count; ++j)
                    a[idx++] = aux[i][j];
            }
        }



    }
}
