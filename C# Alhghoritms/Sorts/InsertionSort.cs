using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.Sorts
{
    public class InsertionSort
    {
        public void Sort(int[] array)
        {
            var arrayCount = array.Length;
            for (var i = 1; i < arrayCount; i++)
            {
                var key = array[i];
                var j = i - 1;

                // Перемещаем элементы массива, которые больше key, на одну позицию вперёд
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                // Вставляем key на своё правильное место
                array[j + 1] = key;
            }
        }
    }
}
