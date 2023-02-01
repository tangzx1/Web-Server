using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test5
    {
        public static int GetMinLeafNode(string str)
        {
            List<int> list = str.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
            int count = list.Count;
            int min = -1;
            for (int i = (count - 1) / 2; i < count; i++)
            {
                if (list[i] != -1)
                {
                    if (min > list[i])
                    {
                        min = list[i];
                    }
                    else
                    {
                        if (min == -1)
                            min = list[i];
                    }
                }
            }
            return min;


        }
    }
}
