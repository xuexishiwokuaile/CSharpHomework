using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Square
    {
        private double length;
        private double area;

        public void GetArea(double length)
        {
            this.length = length;
            this.area = this.length * this.length;
            Console.WriteLine("正方形的面积为：" + this.area);
        }
    }
}
