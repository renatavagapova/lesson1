using System;
using System.Collections;
using System.Collections.Generic;

namespace lesson2
{
    class BinarySearch
    {
        public static int Binary(int[] array, int searchedValue, int first, int last)
        {
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            var middle = (first + last) / 2;
            //значение в средине подмассива
            var middleValue = array[middle];

            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return Binary(array, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return Binary(array, searchedValue, middle + 1, last);
                }
            }
        }
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


            public class Node : ILinkedList
            {
                public int Value { get; set; }
                public Node NextNode { get; set; }
                public Node PrevNode { get; set; }

                public Node firstNode;//первый(стартовый) элемент
                public Node lastNode;//последний(конечный) элемент
                int count;//кол-во элементов всписке


                public int GetCount() => count;

                public void AddNode(int value)
                {
                    var newNode = new Node { Value = value };

                    if (firstNode == null)
                    {
                        firstNode = lastNode = newNode;
                    }
                    else
                    {
                        lastNode.NextNode = newNode;
                        lastNode = newNode;
                    }
                    count++;
                }

                public void AddNodeAfter(Node node, int value)
                {
                    if (value > count || value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                    {
                        var next = node.NextNode;
                        var newOne = new Node() { Value = value, NextNode = next, PrevNode = node };
                        node.NextNode = newOne;
                        if (next != null) next.PrevNode = newOne;
                        count++;
                    }
                }

                private Node GetNodeOnIndex(int index)
                {
                    if (IsIndexNotInRange(index)) return null;

                    Node needed;

                    if (count - 1 / 2 >= index)
                    {
                        needed = firstNode;
                        for (var i = 1; i <= index; i++)
                        {
                            needed = needed.NextNode;
                        }
                    }
                    else
                    {
                        needed = lastNode;
                        for (var i = count - 1; i > index; i--)
                        {
                            needed = needed.PrevNode;
                        }
                    }

                    return needed;
                }

                public void RemoveNode(int index)
                {
                    if (IsIndexNotInRange(index))
                        throw new ArgumentOutOfRangeException();

                    if (index == 0)
                    {
                        if (firstNode.NextNode is { } node)
                        {
                            firstNode = node;
                            node.PrevNode = null;
                        }
                        else firstNode = lastNode = null;
                    }
                    else
                    {
                        var toRemove = GetNodeOnIndex(index);

                        if (toRemove.NextNode != null)
                            toRemove.NextNode.PrevNode = toRemove.PrevNode;
                        toRemove.PrevNode.NextNode = toRemove.NextNode;
                        toRemove.NextNode = toRemove.PrevNode = null;
                    }
                    count--;
                }



                private bool IsIndexNotInRange(int index) => index < 0 || index >= count;
                public void RemoveNode(Node node)
                {
                    
                    if (firstNode == node)
                    {
                        if (firstNode == lastNode)
                        {
                            firstNode = lastNode = null;
                        }
                        else
                        {
                            firstNode = node.NextNode;
                            node.NextNode = null;
                            firstNode.PrevNode = null;
                        }
                    }
                    else
                    {
                        if (node.NextNode != null)
                    node.NextNode.PrevNode = node.PrevNode;
                        node.PrevNode.NextNode = node.NextNode;
                        node.NextNode = node.PrevNode = null;
                    }

                }


                public Node FindNode(Node node, int searchValue)
                {
                    var currentnode = node.firstNode;

                    while (currentnode != null)
                    {
                        if (currentnode.Value == searchValue)
                        {
                            return currentnode;
                        }
                        else
                        {
                            currentnode = currentnode.NextNode;
                        }
                    }
                    return null;
                }

               

             
            }


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
                var searchResult = Binary(array, key, 0, array.Length - 1);
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
}

