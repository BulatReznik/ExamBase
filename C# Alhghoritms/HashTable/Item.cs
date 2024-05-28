using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Alhghoritms.HashTable
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
}
