using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。
namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[length];
            Console.WriteLine("请输入数组内容");
            int max, min, aver, sum;

            for(int i=0;i<length;i++)
            {
                a[i]= Convert.ToInt32(Console.ReadLine());
            }

            max = min = sum= a[0];

            for (int i = 1; i < length; i++)
            {
                sum = sum + a[i];
                if(max<a[i])
                {
                    max = a[i];
                }
                if(min>a[i])
                {
                    min = a[i];
                }
            }
            aver = sum / length;
            Console.WriteLine("最大值：" + max +"最小值: "+min+"平均值: "+aver+"算术和: "+sum);
        }
    }
}
