using System;
using Week6;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Week6.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);

            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);
            OrderService os2 = new OrderService();
            os2.orderDict.Add(1, order1);
            os2.orderDict.Add(2, order2);

            os1.AddOrder(order2);

            CollectionAssert.Equals(os1, os2);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);

            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);
            OrderService os2 = new OrderService();
            os2.orderDict.Add(1, order1);
            os2.orderDict.Add(2, order2);

            os2.RemoveOrder(2);

            CollectionAssert.Equals(os1, os2);
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            CollectionAssert.Equals(os1.orderDict.Values.ToList(), os1.QueryAllOrders());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            CollectionAssert.Equals(os1.orderDict[1], os1.GetById(1));
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            Goods milk = new Goods(1, "milk", 69.9);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            var query = os1.orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == "milk")
                    .Count() > 0
                );

            CollectionAssert.Equals(query.ToList(), os1.QueryByGoodsName("milk"));
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            var query = os1.orderDict.Values
                .Where(order => order.Customer.Name == "customer1");

            CollectionAssert.Equals(query.ToList(), os1.QueryByCustomerName("customer1"));
        }

        [TestMethod()]
        public void QueryByPriceTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            var query = os1.orderDict.Values
                .Where(order => order.Amount > 100);

            CollectionAssert.Equals(query.ToList(), os1.QueryByPrice(100));
        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(1, customer1);
            OrderService os1 = new OrderService();
            os1.orderDict.Add(1, order1);

            Customer newCustomer = new Customer(3, "newCustomer");
            os1.orderDict[1].Customer = newCustomer;

            OrderService os2 = new OrderService();
            os2.orderDict.Add(1, order1);
            os2.UpdateCustomer(1, newCustomer);

            CollectionAssert.Equals(os1.orderDict, os2.orderDict);
        }
    }
}