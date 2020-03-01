using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//3.用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再去掉4的倍数，以此类推...最后剩下的就是素数。

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isprime = new bool[101];

            for (int i = 0; i <= 100; i++)
                isprime[i] = true;
            isprime[0] = isprime[1] = false;

            for (int i = 2; i <= 100; i++)
            {
                if (isprime[i])
                {
                    for (int j = 2 * i; j <= 100; j += i)
                    {
                        isprime[j] = false;
                    }
                }
            }

            for (int i = 0; i <= 100; i++)
            {
                if (isprime[i])
                {
                    Console.Write(i+" ");
                }
            }
        }
    }
}
