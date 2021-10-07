using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
