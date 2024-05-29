using System;

namespace C__Alhghoritms.HashTable
{
    public class HashTable
    {
        private readonly Item[] _items;
        private readonly int _maxSize;

        public HashTable(int maxSize = 100)
        {
            _maxSize = maxSize;
            _items = new Item[_maxSize];
        }

        /// <summary>
        /// Хэш-функция для вычисления индекса по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Индекс в массиве</returns>
        private int GetHash(string key)
        {
            // Сложность: O(1)
            return Math.Abs(key.GetHashCode()) % _maxSize;
        }

        /// <summary>
        /// Вставка элемента в хэш-таблицу
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(string key, string? value)
        {
            var item = new Item(key, value);
            var hash = GetHash(key);

            // Поиск пустого слота для вставки
            // Сложность: В среднем O(1), в худшем случае O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i) % _maxSize;

                if (_items[index] == null || _items[index].Key == key)
                {
                    _items[index] = item;
                    return;
                }
            }

            throw new Exception("Таблица пуста");
        }

        /// <summary>
        /// Поиск элемента в хэш-таблице
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Значение элемента</returns>
        public string? Search(string key)
        {
            var hash = GetHash(key);

            // Поиск элемента по ключу
            // Сложность: В среднем O(1), в худшем случае O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i) % _maxSize;

                if (_items[index] == null)
                    return null;

                if (_items[index].Key == key)
                    return _items[index].Value;
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

            // Поиск и удаление элемента по ключу
            // Сложность: В среднем O(1), в худшем случае O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i) % _maxSize;

                if (_items[index] == null)
                    return;

                if (_items[index].Key == key)
                {
                    _items[index] = null;
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }
    }
}
