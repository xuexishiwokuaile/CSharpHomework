using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public bool JudgeNumbers(int number)            //判断一个数是否为素数
        {
            int sum = 0;
            for(int i=1;i<=number;i++)
            {
                if(number%i==0)
                {
                    sum += 1;
                }
            }
            if(sum == 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetNumbers(int number)
        {
            if (number <= 1)
                return false;
            else      //number>=2
            {
                int i = 2;
                for(; i<=number;i++)
                {
                    //判断i是否是素数
                    if (JudgeNumbers(i)) continue;
                    if(number%i == 0)
                    {
                        number /= i;
                        Console.Write(i+"\n");
                        Console.ReadKey();
                        i = 2;
                    }
                }
                if (number != 1)
                {
                    Console.Write(number);
                    Console.ReadKey();
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("请输入一个数字：\n");
            String str = Console.ReadLine();             //从控制台读取输入
            int number = Convert.ToInt32(str);
            Program program = new Program();
            Console.Write("它的素数因子为：\n");
            program.GetNumbers(number);
        }
    }
}
