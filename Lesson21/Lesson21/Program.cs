namespace Lesson21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("customer1", 55);
            var customer2 = new Customer("customer2", 50);
            var prod1 = new Product("bread", ProductCategory.Food, 100);
            var prod2 = new Product("bread2", ProductCategory.Food, 100);
            var prod3 = new Product("bread3", ProductCategory.Food, 100);
            var prods = new Product[] { prod1, prod2, prod3 };
            var order = new Order(customer, prods);
            var order2 = new Order(customer2, prods);
            var warehouse = new Warehouse();
            warehouse.AddProduct(prod1.Id, 4);

            Console.WriteLine(customer.ToString());
            Console.WriteLine(customer2.ToString());
            Console.WriteLine(order.ToString());
            Console.WriteLine(order2.ToString());

            var market = new Marketplace();
            market.AddProduct(prod1, 10);
            market.AddProduct(prod2, 20);
            market.AddProduct(prod3, 30);

            market.RegisterCustomer(customer);
            market.PlaceOrder(order);

            market.RegisterCustomer(customer2);
            market.PlaceOrder(order2);

            market.ExecuteNextOrder();
            market.PrintReport();



        }
    }
}
