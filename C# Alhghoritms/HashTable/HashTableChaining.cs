using C__Alhghoritms.HashTable;

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

        private int GetHash(string key)
        {
            return Math.Abs(key.GetHashCode()) % _items.Length;
        }

        public void Insert(string key, string? value)
        {
            var item = new Item(key, value);
            var hash = GetHash(key);
            _items[hash].Add(item);
        }

        public string? Search(string key)
        {
            var hash = GetHash(key);
            foreach (var item in _items[hash])
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public void Remove(string key)
        {
            var hash = GetHash(key);
            var itemToRemove = _items[hash].FirstOrDefault(item => item.Key == key);
            if (itemToRemove != null)
            {
                _items[hash].Remove(itemToRemove);
            }
        }
    }
}