using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21
{
    internal class Warehouse
    {
        private Dictionary<string, int> _storage;
        public int this[string id]
        {
            get { return _storage[id]; }
            set 
            {
                if (_storage.ContainsKey(id))
                    _storage[id] = value;
            }
        }

        public Warehouse()
        {
            _storage = new Dictionary<string, int>();
        }

        public void AddProduct(string id, int amount)
        {
            if (_storage.ContainsKey(id))
            {
                _storage[id] += amount;
            }
            _storage[id] = amount;
        }

        public void PickUpProduct(string id, int amount)
        {
            if (_storage.ContainsKey(id))
            {
                _storage[id] -= amount;
                if (_storage[id] <= 0)
                {
                    _storage.Remove(id);
                }
            }
            
        }

    }
}
