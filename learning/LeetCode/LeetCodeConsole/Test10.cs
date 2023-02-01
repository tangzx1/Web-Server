using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test10
    {
        // absent:    缺勤
        // late:      迟到
        // leaveearly:早退
        // present:   正常上班
        public static bool GetResult(List<string> list)
        {
            if (list.Count == 1)
            {
                if (list[0] != "present")
                    return false;
            }
            List<string> conditionsA = new()
            {
                "late","leaveearly"
            };
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (conditionsA.Contains(list[i]) && conditionsA.Contains(list[i + 1]))
                    return false;
            }

            if (list.Count >= 7)
            {
                List<string> conditionsB = new()
            {
                "late","leaveearly","absent"
            };
                for (int i = 0; i < list.Count - 6; i++)
                {
                    int number = 0;
                    List<string> strs = list.GetRange(i,7);
                    foreach(var item in strs)
                    {
                        if (conditionsB.Contains(item))
                            number++;
                    }

                    if (number >= 3)
                        return false;
                    
                }
            }

            return true;

        }
    }
}
