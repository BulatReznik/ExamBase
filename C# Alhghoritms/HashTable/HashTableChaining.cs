using C__Alhghoritms.HashTable;
using System.Collections.Generic;
using System.Linq;

namespace C__Algorithms
{
    public class HashTableChaining
    {
        private readonly List<Item>[] _items;

        public HashTableChaining(int maxSize = 100)
        {
            _items = new List<Item>[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                _items[i] = new List<Item>();
            }
        }

        /// <summary>
        /// Хэш-функция для вычисления индекса по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Индекс в массиве</returns>
        private int GetHash(string key)
        {
            // Сложность: O(1)
            return Math.Abs(key.GetHashCode()) % _items.Length;
        }

        /// <summary>
        /// Вставка элемента в хэш-таблицу с использованием метода цепочек
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(string key, string? value)
        {
            var item = new Item(key, value);
            var hash = GetHash(key);

            // Вставка элемента в связный список
            // Сложность: O(1) в среднем случае, O(n) в худшем случае при всех равных хэшах
            _items[hash].Add(item);
        }

        /// <summary>
        /// Поиск элемента в хэш-таблице
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Значение элемента</returns>
        public string? Search(string key)
        {
            var hash = GetHash(key);

            // Поиск элемента в связном списке по ключу
            // Сложность: O(1) в среднем случае, O(n) в худшем случае при всех равных хэшах
            foreach (var item in _items[hash])
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// Удаление элемента из хэш-таблицы
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            var hash = GetHash(key);

            // Поиск и удаление элемента в связном списке по ключу
            // Сложность: O(1) в среднем случае, O(n) в худшем случае при всех равных хэшах
            var itemToRemove = _items[hash].FirstOrDefault(item => item.Key == key);
            if (itemToRemove != null)
            {
                _items[hash].Remove(itemToRemove);
            }
        }
    }
}
