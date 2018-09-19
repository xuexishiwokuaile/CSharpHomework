using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private int[] numbersArray;

        public void InitArray(int [] numbersArray)
        {
            this.numbersArray = numbersArray;
        }

        public int GetMax(int[]a)
        {
            int i = a[0];
            int temp;
            for(int j=0;j<a.Length;j++)
            {
                if (i<a[j])
                {
                    temp = i;
                    i = a[j];
                    a[j] = temp;
                }
            }
            Console.Write("最大值为:\n");
            Console.Write(i+"\n");
            Console.ReadKey();
            return i;
        }

        public int GetMin(int []a)
        {
            int i = a[0];
            int temp;
            for (int j = 0; j < a.Length; j++)
            {
                if (i >= a[j])
                {
                    temp = i;
                    i = a[j];
                    a[j] = temp;
                }
            }
            Console.Write("最小值为:\n");
            Console.Write(i + "\n");
            Console.ReadKey();
            return i;
        }

        public double GetAverage(int []a)
        {
            int sum = 0;
            for(int i=0;i<a.Length;i++)
            {
                sum += a[i];
            }
            double average = sum / a.Length;
            Console.Write("平均值为:\n");
            Console.Write(average + "\n");
            Console.ReadKey();
            return average;
        }

        public int GetSum(int []a)
        {
            int sum = 0;
            for(int i=0;i<a.Length;i++)
            {
                sum += a[i];
            }
            Console.Write("所有数组元素的和为:\n");
            Console.Write(sum);
            Console.ReadKey();
            return sum;
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 3, 2, 5, 4 };
            Program program = new Program();
            program.InitArray(a);
            program.GetMax(a);
            program.GetMin(a);
            program.GetAverage(a);
            program.GetSum(a);
        }
    }
}
