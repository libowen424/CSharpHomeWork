using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caculator
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                double firstNumber, secondNumber;
                char sign;
                Console.WriteLine("请输入第一个数");
                firstNumber = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.WriteLine("请输入第二个数");
                secondNumber = Double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                Console.WriteLine("请输入符号");
                sign = Char.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                switch (sign)
                {
                    case '+':
                        Console.Write("答案是 ");
                        Console.WriteLine(firstNumber + secondNumber);
                        break;
                    case '-':
                        Console.Write("答案是 ");
                        Console.WriteLine(firstNumber - secondNumber);
                        break;
                    case '*':
                        Console.Write("答案是 ");
                        Console.WriteLine(firstNumber * secondNumber);
                        break;
                    case '/':
                        if(secondNumber==0)
                        {
                            Console.Write("被除数不能为0 ");
                        }
                        Console.Write("答案是 ");
                        Console.WriteLine(firstNumber / secondNumber);
                        break;
                    default:
                        Console.WriteLine("请输入一个符号！！！");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
