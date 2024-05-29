using C__Alhghoritms.HashTable;

namespace C__Algorithms
{
    public class HashTableDoubleHashing
    {
        private readonly Item[] _items;
        private readonly int _maxSize;

        public HashTableDoubleHashing(int maxSize = 100)
        {
            _maxSize = maxSize;
            _items = new Item[_maxSize];
        }

        /// <summary>
        /// Первая хеш-функция
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetHash(string key)
        {
            // Сложность: O(1)
            return Math.Abs(key.GetHashCode()) % _maxSize;
        }

        /// <summary>
        /// Вторая хэш-функция
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int GetHash2(string key)
        {
            // Сложность: O(1)
            return 7 - (Math.Abs(key.GetHashCode()) % 7);
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

            // Цикл поиска свободного места с использованием двойного хэширования
            // Сложность в среднем случае: O(1), в худшем случае: O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i * GetHash2(key)) % _maxSize; // Двойное хэширование

                if (_items[index] == null || _items[index].Key == key)
                {
                    _items[index] = item;
                    return;
                }
            }

            throw new Exception("HashTable полностью заполнена");
        }

        /// <summary>
        /// Поиск элемента в хэш-таблице
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? Search(string key)
        {
            var hash = GetHash(key);

            // Цикл поиска элемента с использованием двойного хэширования
            // Сложность в среднем случае: O(1), в худшем случае: O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i * GetHash2(key)) % _maxSize;

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

            // Цикл поиска и удаления элемента с использованием двойного хэширования
            // Сложность в среднем случае: O(1), в худшем случае: O(n)
            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i * GetHash2(key)) % _maxSize;

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
