using System;
using System.Collections;
using System.Collections.Generic;

namespace lesson2
{
    
        class Program
        {
            #region Задания
            /*
             * Задание 1
             * Требуется реализовать класс двусвязного списка и выполнить операции:
             * - вставки
             * - удаления 
             * - поиска элемента в нём
             * __________________________________
             * Задание 2
             * Требуется написать функцию бинарного поиска, 
             * посчитать его асимптотическую сложность и 
             * проверить работоспособность функции.

             */
            #endregion

            //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
            public interface ILinkedList
            {
                int GetCount(); // возвращает количество элементов в списке  
                void AddNode(int value);  // добавляет новый элемент списка             
                void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
                void RemoveNode(int index); // удаляет элемент по порядковому номеру
                void RemoveNode(Node node); // удаляет указанный элемент
                Node FindNode(Node node, int searchValue); // ищет элемент по его значению
               
            }


            static void Main(string[] args)
            {
                Console.WriteLine("Задание 2");
                int[] array = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
                Console.WriteLine("Введите искомый целочисленный элемент в массиве");
                int key = int.Parse(Console.ReadLine());
                var searchResult = BinarySearch.Binary(array, key, 0, array.Length - 1);
                if (searchResult < 0)
                {
                    Console.WriteLine("Элемент со значением {0} не найден", key);
                }
                else
                {
                    Console.WriteLine("Элемент найден. Индекс элемента со значением {0} равен {1}", key, searchResult);
                }

            }


        }

    
}

