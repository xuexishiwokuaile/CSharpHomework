using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Triangle
    {
        private double a;
        private double b;
        private double c;
        private double area;

        public void GetArea(double a,double b,double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            if(a+b<=c||a+c<=b||b+c<=a)
            {
                Console.WriteLine("不能构成三角形");
            }
            else
            {
                double p = (this.a+this.b+this.c)*0.5;
                double temp = p * (p - this.a) * (p - this.b) * (p - this.c);
                this.area = System.Math.Pow(temp, 0.5);
                Console.WriteLine("三角形的面积为：" +  this.area);
            } 
        }

        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle();
            Console.WriteLine("请输入三角形的三边长:");
            String str1 = Console.ReadLine();
            String str2 = Console.ReadLine();
            String str3 = Console.ReadLine();
            double a = Convert.ToDouble(str1);
            double b = Convert.ToDouble(str2);
            double c = Convert.ToDouble(str3);
            triangle.GetArea(a, b, c);
            Circle circle = new Circle();
            Console.WriteLine("请输入圆的半径：");
            String str4 = Console.ReadLine();
            double radius = Convert.ToDouble(str4);
            circle.GetArea(radius);
            Square square = new Square();
            Console.WriteLine("请输入正方形的边长：");
            String str5 = Console.ReadLine();
            double length = Convert.ToDouble(str5);
            square.GetArea(length);
            Rectangle rectangle = new Rectangle();
            Console.WriteLine("请输入长方形的长和宽：");
            String str6 = Console.ReadLine();
            String str7 = Console.ReadLine();
            double width = Convert.ToDouble(str6);
            double height = Convert.ToDouble(str7);
            rectangle.GetArea(width, height);
            Console.ReadKey();
        }
    }
}
