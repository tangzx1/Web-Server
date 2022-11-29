using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test4
    {
        public static bool IsChild(string s, string t)
        {
            int sCount = s.Length;
            int tCount = t.Length;
            if (sCount > tCount)
            {
                return false;
            }
            string result = string.Empty;
            int tIndex = 0;
            for (int sIndex = 0; sIndex < sCount; sIndex++)
            {
                if (tIndex == tCount)
                {
                    if (result == s)
                        return true;
                    else
                        return
                            false;
                }
                for (; tIndex < tCount; tIndex++)
                {
                    if (s[sIndex] == t[tIndex])
                    {
                        result += s[sIndex];
                        break;
                    }
                }
            }

            if (result == s)
                return true;
            else
                return
                    false;

        }


    }
}
