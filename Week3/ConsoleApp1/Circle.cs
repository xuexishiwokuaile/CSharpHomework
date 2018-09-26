using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Circle
    {
        public double radius;
        private double area;

        public void GetArea(double radius)
        {
            this.radius = radius;
            this.area = System.Math.PI * (this.radius * this.radius);
            Console.WriteLine("圆的面积为：" + this.area);
        }
    }
}
