using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Week6
{
    [Serializable]
    public class OrderService
    {
        public Dictionary<uint, Order> orderDict;

        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        public void RemoveOrder(uint orderId)
        {
            orderDict.Remove(orderId);
        }

        public List<Order>QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.Amount > price);
            return query.ToList();
        }

        public void UpdateCustomer(uint orderId,Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        //序列化
        public void Export(Order os)
        {
            try
            {
                FileStream fs = new FileStream("test.xml", FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(OrderService));
                xs.Serialize(fs, os);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("序列化成功！");

            Console.Read();
        }

        //反序列化
        public void Import()
        {
            try
            {
                FileStream fs = new FileStream("test.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(OrderService));
                Order os = (Order)xs.Deserialize(fs);
                Console.WriteLine(os.Id);
                Console.WriteLine(os.Amount);
                Console.WriteLine(os.Details);
                Console.WriteLine(os.Customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();
            Console.Read(); 
            Console.Read();
            Console.Read();
            Console.Read();
        }

        public void Convert()        //将xml转化为html
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load("test.xsl");
            trans.Transform("test.xml", "out.html");
        }
    }
}