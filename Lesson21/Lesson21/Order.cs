using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21
{
    enum OrderStatus
    {
        Created,
        Pending,
        Postponed,
        Completed,
        Cancelled
    }
    internal class Order
    {
        private static int _nextOrderId;

        public OrderStatus Status {  get; set; }

        public int Id { get; }
        public Customer Customer
        {
            get;
        }

        public Product[] Cart
        {
            get;
        }

        public double TotalPrice
        { 
            get
            {
                var s = 0.0;
                foreach (var item in Cart)
                {
                    s += item.Price;
                }
                return s;
            }
        }

        public Order(Customer customer, Product[] cart)
        {
            Id = _nextOrderId;
            _nextOrderId++;
            Customer = customer;

            Cart = cart;

        }

        public string ToString()
        {
            var s = "";
            foreach (var item in Cart)
            {
                s += item.ToString();
            }
            return $"Id: {Id}\nCustomer: {Customer}\nStatus: {Status}\nTotalPrice: {TotalPrice}\nCart:\n "+s+"\n";
        }

    }
}
