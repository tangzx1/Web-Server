using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test14
    {
        // 勾股元组数
        public static void GetResult1(int start, int end)
        {
            List<int> listA = new();
            List<int> listB = new();
            List<int> listC = new();
            for (int a = start; a < end - 1; a++)
            {
                for (int b = a + 1; b < end; b++)
                {
                    for (int c = b + 1; c <= end; c++)
                    {
                        if (a * a + b * b == c * c && Gcd(b, a) == 1 && Gcd(c, a) == 1 && Gcd(c, b) == 1)
                        {
                            listA.Add(a);
                            listB.Add(b);
                            listC.Add(c);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(',', listA.OrderBy(x => x)));
            Console.WriteLine(string.Join(',', listB.OrderBy(x => x)));
            Console.WriteLine(string.Join(',', listC.OrderBy(x => x)));
        }

        static int Gcd(int numberA, int numberB)
        {
            if (numberB == 0)
            {
                return numberA;
            }
            return Gcd(numberB, numberA % numberB);
        }

        //TLV解码
        public static void GetResult4(string tagA, string tagB)
        {
            List<string> list = tagB.Split(' ').ToList();
            for (int i = 0; i < list.Count - 3;)
            {
                int length = Convert.ToInt32(list[i + 1].Substring(0, 1)) * 16 + Convert.ToInt32(list[i + 1].Substring(1, 1)) + Convert.ToInt32(list[i + 2].Substring(0, 1)) * 16 * 16 * 16 + Convert.ToInt32(list[i + 2].Substring(1, 1)) * 16 * 16;
                if (list[i] == tagA)
                {
                    List<string> result = list.GetRange(i + 3, length);
                    Console.WriteLine(string.Join(' ', result));
                }
                i = i + 2 + length + 1;
            }

        }

        //猴子跳台阶 1级和3级
        public static void GetResult5(int step)
        {
            Console.WriteLine(Climb(step, 0));
        }

        static int Climb(int total, int now)
        {
            if (now + 3 < total)
            {
                return Climb(total, now + 1) + Climb(total, now + 3);
            }
            else if (now + 3 == total)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }


    }

}
