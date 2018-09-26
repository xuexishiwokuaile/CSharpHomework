using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Rectangle
    {
        private double width;
        private double height;
        private double area;

        public void GetArea(double width,double height)
        {
            this.width = width;
            this.height = height;
            this.area = this.width * this.height;
            Console.WriteLine("长方形的面积为：" + this.area);
        }
    }
}
