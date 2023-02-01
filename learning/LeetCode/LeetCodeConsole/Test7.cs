using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test7
    {
        public static string GetResult(string input)
        {
            string result = "0";
            List<int> list = input.Split(' ').Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            int count = list.Count;
            for (int i = count - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        if (j != k && list[i] == (list[j] + 2 * list[k]))
                        {
                            return list[i] + " " + list[j] + " " + list[k];
                        }
                    }

                }
            }



            return result;
        }
    }
}
