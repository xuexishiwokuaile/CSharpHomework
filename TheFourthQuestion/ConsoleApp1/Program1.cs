using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program1
    {
        static void Main(string[] args)
        {
            Console.Write("请输入两个数：");
            Console.Write("\n");
            int i = Convert.ToInt32(Console.ReadLine());
            int j = Convert.ToInt32(Console.ReadLine());
            Console.Write("这两个数的积为：");
            Console.Write("\n");
            int k = i * j;
            Console.Write(k);
            Console.ReadKey();
        }
    }
}