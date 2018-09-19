using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public void GetNumbers()
        {
            ArrayList numbers = new ArrayList();           //建立一个动态数组存储这些数
            for (int i = 2;i <= 100;i++)
            {
                numbers.Add(i);
            }
            for (int j = 2; j <= 50; j++)
            {
                for (int k = j*2; k <= 100; k += j)
                {
                    numbers.Remove(k);
                }
            }
            Console.Write("2-100的素数有：\n");
            Console.ReadKey();
            for (int u = 0; u < numbers.Count; u++)
            {
                Console.Write(numbers[u]+"\n");
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetNumbers();
        }
    }
}
