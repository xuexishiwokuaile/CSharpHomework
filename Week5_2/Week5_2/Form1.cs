using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.CreateGraphics();
            drawCayleyTree(14, 250, 280, 50, -Math.PI / 2, 2.0);
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void drawCayleyTree(int n,double x0,double y0,
            double leng,double th,double k)
        {
            if (n == 0)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + k * leng * Math.Cos(th);
            double y2 = y0 + k * leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, x2, y2);

            k -= 0.1;

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1, k);
            drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2, k);     //两颗子树
        }

        void drawLine(double x0, double y0, double x1, double y1, double x2, double y2)
        {
            Pen pen;
            Random rd = new Random();
            switch(rd.Next(1,6))
            {
                case 1:
                    pen = new Pen(Color.Blue, 2);
                    break;
                case 2:
                    pen = new Pen(Color.Red, 3);
                    break;
                case 3:
                    pen = new Pen(Color.Black, 4);
                    break;
                case 4:
                    pen = new Pen(Color.Green, 1);
                    break;
                case 5:
                    pen = new Pen(Color.Yellow, 1);
                    break;
                default:
                    pen = new Pen(Color.Gray, 1);
                    break;
            }
            graphics.DrawLine(pen, (int)x0,(int)y0,(int)x1,(int)y1);
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x2, (int)y2);
        }
    }
}