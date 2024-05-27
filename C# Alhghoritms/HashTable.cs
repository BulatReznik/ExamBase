namespace C__Algorithms
{
    public class Item
    {
        public string Key { get; set; }
        public string? Value { get; set; }

        public Item(string key, string? value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Ключ не может быть пустым", nameof(key));

            Key = key;
            Value = value;
        }
    }

    public class HashTable
    {
        private readonly Item[] _items;
        private readonly int _maxSize;

        public HashTable(int maxSize = 100)
        {
            _maxSize = maxSize;
            _items = new Item[_maxSize];
        }

        private int GetHash(string key)
        {
            return Math.Abs(key.GetHashCode()) % _maxSize;
        }

        public void Insert(string key, string? value)
        {
            var item = new Item(key, value);
            var hash = GetHash(key);

            for (var i = 0; i < _maxSize; i++)
            {
                var index = (hash + i) % _maxSize;

                if (_items[index] == null || _items[index].Key == key)
                {
                    _items[index] = item;
                    return;
                }
            }

            throw new Exception("HashTable is full");
        }

        public string? Search(string key)
        {
            var hash = GetHash(key);

            var count = 0;

            for (var i = 0; i < _maxSize; i++)
            {
                count++;

                var index = (hash + i) % _maxSize;

                if (_items[index] == null)
                    return null;

                if (_items[index].Key == key)
                    return _items[index].Value + "" + count;
            }

            return null;
        }

        public void Remove(string key)
        {
            var hash = GetHash(key);

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
