using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//编写程序输出用户指定数据的所有素数因子。

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数");
            int number = Convert.ToInt32(Console.ReadLine());
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {

                    for(bool flag=true; ;)
                    {
                        if (number % i == 0)
                        {
                        Console.WriteLine(i);
                            number /= i;
                        }
                        else
                        {
                        flag = false;
                        }
                    }
                }
                if (number != 1)
                {
                Console.WriteLine(number);
                }
            }

        }

}
