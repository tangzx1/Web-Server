using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test8
    {
        public static string GetResult(int length, List<List<int>> list)
        {
            List<int> res = new();
            bool flag = true;
            while(flag)
            {
                bool temp = true;
                foreach (var item in list)
                {
                    if (item.Count > 0)
                    {
                        temp = false;
                        if (item.Count > length)
                        {
                            res.AddRange(item.GetRange(0, length));
                            item.RemoveRange(0, length);
                        }
                        else
                        {
                            res.AddRange(item);
                            item.RemoveRange(0, item.Count);
                        }
                    }
                }
                if (temp)
                {
                    flag = false;
                }
            }



            return string.Join(',', res);
        }
    }
}
