using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3
{
    class Program
    {
        public class Order
        {
            private string type;
            public void createOrder()
            {
                Console.WriteLine("请输入您要执行的操作：/n");
                Console.WriteLine("1.添加订单\t2.删除订单/t3.修改订单\t4.查询订单\n");
                string str = Console.ReadLine();
                int type = Convert.ToInt32(str);
                switch (type)
                {
                    case 1:
                        addOrder();
                        break;
                    case 2:
                        deleteOrder();
                        break;
                    case 3:
                        changeOrder();
                        break;
                    case 4:
                        searchOrder();
                        break;
                }
            }

            public virtual void addOrder()
            {
            }
            public virtual void deleteOrder()
            {
            }
            public virtual void changeOrder()
            {
            }
            public virtual void searchOrder()
            {
            }
        }

        public class OrderDetails:Order
        {
            public List<String> orderList = new List<String>();
            public void displayOrder()
            {
                foreach(String s in orderList)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public class OrderService : OrderDetails
        {
            public override void addOrder()
            {
                String order;
                Console.WriteLine("输入商品名：\n");
                order = Console.ReadLine();
                order += " ";
                Console.WriteLine("输入订单号：\n");
                order = Console.ReadLine();
                orderList.Add(order);
                Console.WriteLine("添加成功！\n");
                displayOrder();
                createOrder();
            }
            public override void deleteOrder()
            {
                String OrderNumber;
                Console.WriteLine("输入订单号：\n");
                OrderNumber = Console.ReadLine();
                foreach(String s in orderList)
                {
                    try
                    {
                        int pos = s.LastIndexOf(" ");
                        String subString = s.Substring(pos + 1, 3);
                        if(subString == OrderNumber)
                        {
                            orderList.Remove(s);
                            Console.WriteLine("删除完成！\n");
                            break;
                        }
                    }
                    catch(IndexOutOfRangeException e)
                    {
                        Console.WriteLine("删除失败！\n");
                    }
                }
                displayOrder();
                createOrder();
            }
            public override void changeOrder()
            {
                String orderNumber;
                Console.WriteLine("输入订单号：\n");
                orderNumber = Console.ReadLine();
                foreach(String s in orderList)
                {
                    try
                    {
                        int pos = s.LastIndexOf(" ");
                        string subString = s.Substring(pos + 1, 3);
                        if (subString == orderNumber)
                        {
                            Console.WriteLine("输入新商品名：");
                            String good = Console.ReadLine();
                            string[] orderArray = s.Split(' ');
                            orderArray[1] = good;
                            String newOrder = "";
                            for (int i = 0; i < 3; i++)
                            {
                                newOrder += orderArray[i];
                                if (i < 2)
                                {
                                    newOrder += " ";
                                }
                            }
                            orderList.Remove(s);
                            orderList.Add(newOrder);
                            Console.WriteLine("修改完成");
                            break;
                        }
                    }
                    catch(ArrayTypeMismatchException e)
                    {
                        Console.WriteLine("修改失败：\n");
                    }
                }
                displayOrder();
                createOrder();
            }
            public override void searchOrder()
            {
                Console.WriteLine("1.按商品名称查询\t2.按订单号查询\n");
                String str1 = Console.ReadLine();
                int type = Convert.ToInt32(str1);
                switch(type)
                {
                    case 1:
                        foreach (String s in orderList)
                        {
                            Console.WriteLine("输入商品名：");
                            String good = Console.ReadLine();
                            string[] orderArray = s.Split(' ');
                            if (orderArray[1] == good)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                    case 2:
                        foreach (String s in orderList)
                        {
                            Console.WriteLine("输入订单号：");
                            String num = Console.ReadLine();
                            string[] orderArray = s.Split(' ');
                            if (orderArray[0] == num)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;
                }
                displayOrder();
                createOrder();
            }
        }
        static void Main(string [] args)
        {
            OrderService order = new OrderService();
            order.createOrder();
        }
    }
}