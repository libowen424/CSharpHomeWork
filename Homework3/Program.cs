using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口、属性来实现。

namespace ConsoleApp5
{
    public interface Shape  
    {
          double getarea();
          bool islegal();
    }

     class Rectangle : Shape
    {
         double length, width;
        public Rectangle(double l,double w)
        {
                length = l;
                width = w;
        }
         public double getarea()
        {
            if (islegal())
                return length * width;
            else
                return 0;
        }
        public bool islegal()
        {
            return length > 0 && width > 0;
        }
        public double LENGTH
        {
            get => length;
            set => length = value;

        }
        public double WIDTH 
        {
            get => width;
            set => width = value; 
        }
    }

     class square : Shape
    {
        double side;
        public square(double l)
        {
                side = l;
        }
        public double getarea()
        {
            if (islegal())
                return side * side;
            else
                return 0; 
        }
        public bool islegal()
        {
            return side > 0 ;
        }
        public double SIDE
        {
            get => side;
            set => side = value;
        }
    }
    class Triangle : Shape
    {
        double a, b, c;
        public Triangle(double A, double B, double C)
        {
            if (islegal())
            {
                a = A; b = B; c = C;
            }
        }
        public double getarea()
        {
            if (islegal())
            {
                double p = (a + b + c) / 2;//计算半周长
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));//套用海伦公式，计算面积
                return s;
            }
            return 0;
        }
        public bool islegal()
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }
    }

    class ShapeFactory
    {
        public static double getrand(int minValue, int maxValue)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            return ra.NextDouble()*(maxValue-minValue);
        }
        public Shape produce(double type)
        {
            if (type < 1) {
                Rectangle s1 = new Rectangle(getrand(0, 100), getrand(0, 100));
                return s1; }
            if (type < 2) { square s2 = new square(getrand(0, 100));
                return s2; }
            if (type < 3) { Triangle s3 = new Triangle(getrand(0, 100), getrand(0, 100), getrand(0, 100));
                return s3; }
            else
                return null;
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory fac = new ShapeFactory();
            double sum = 0;
            int i = 0;
            while (i < 10)
            {
                Shape s = fac.produce(ShapeFactory.getrand(0, 3));
                Console.WriteLine(s.GetType());
                if (s.islegal())
                {
                    sum = sum + s.getarea();
                    Console.WriteLine("合法");
                    i++;
                }
            }
            Console.WriteLine(sum);
        }
        
    }
}

//2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
