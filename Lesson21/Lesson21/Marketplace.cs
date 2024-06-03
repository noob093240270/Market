using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21
{
    internal class Marketplace
    {
        private List<Customer> _customerDatabase;
        private List<Product> _productDatabase;
        private Queue<Order> _orderQueue;
        private List<Order> _orderHistory;
        private Warehouse _warehouse;

       
        public Dictionary<Product,int> AvailableProducts 
        { 
            get 
            {
                var dic = new Dictionary<Product, int>();
                foreach (var item in _productDatabase)
                {
                    dic.Add(item, _warehouse[item.Id]);
                }
                return dic;
            }
        }

        public Marketplace() 
        {
            _productDatabase = new List<Product>();
            _customerDatabase = new List<Customer>();
            //AvailableProducts = new Dictionary<Product,int>();
            _orderQueue = new Queue<Order>();
            _orderHistory = new List<Order>();
            _warehouse = new Warehouse();
        }


        public void AddProduct(Product product, int amount)
        {
            _warehouse.AddProduct(product.Id, amount);
            _productDatabase.Add(product);
        }

        public void RegisterCustomer(Customer customer)
        {
            _customerDatabase.Add(customer);
        }

        public void PlaceOrder(Order order)
        {
            order.Status = OrderStatus.Created;
            if (!_customerDatabase.Contains(order.Customer))
            {
                Console.WriteLine("no regist");
                order.Status = OrderStatus.Cancelled;
                _orderHistory.Add(order);
                return;
            }
            order.Status = OrderStatus.Pending;
            _orderQueue.Enqueue(order);
        }

        public void ExecuteNextOrder()
        {
            
            var currentOrder = _orderQueue.Dequeue();
            if (currentOrder.Status == OrderStatus.Postponed)
            {
                _orderHistory.Add(currentOrder);
                currentOrder.Status = OrderStatus.Cancelled;
                return;
            }
            /*var dic = new Dictionary<Product,int>();
            foreach (var item in currentOrder.Cart)
            {
                dic[item] = dic[item]+1;
            }*/
            foreach (var item in currentOrder.Cart)
            {
                if (AvailableProducts[item] >= 1)
                {
                    AvailableProducts[item] -= 1;
                    _warehouse.PickUpProduct(item.Id, 1);
                }
                else
                {
                    currentOrder.Status = OrderStatus.Postponed;
                    _orderQueue.Enqueue(currentOrder);
                    return;
                }
            }
            currentOrder.Status = OrderStatus.Completed;
            _orderHistory.Add(currentOrder);
        }


        public void PrintReport()
        {
            foreach (var item in _orderHistory.Where(order=>order.Status == OrderStatus.Completed))
            {
                Console.WriteLine(item.ToString());
            }
            foreach (var item in _orderQueue)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
