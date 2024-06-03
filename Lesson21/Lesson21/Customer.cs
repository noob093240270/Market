using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21
{
    internal class Customer
    {
        private static int _nextCustomerId = 0;
        private string _customerName;
        private int _customerDiscount;
        public int Id { get; }
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("value");
                _customerName = value;
            }
        }
        public int CustomerDiscount
        {
            get { return _customerDiscount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _customerDiscount = value;
            }
        }

        public double Discount { get; }

        public Customer(string name, double discount)
        {
            Id = _nextCustomerId;
            _nextCustomerId++;
            CustomerName = name;
            Discount = discount;

        }

        public string ToString()
        {
            return $"Id: {Id}\nName: {CustomerName}\nDiscount: {Discount}\n";
        }
    }
}
