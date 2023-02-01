using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test6
    {
        public static string GetResult(string input)
        {
            string result = string.Empty;
            //选择内容
            string choose = string.Empty;
            //复制内容
            string copy = string.Empty;

            List<string> list = input.Split(' ').ToList();
            foreach (var item in list)
            {
                switch (item)
                {
                    //a
                    case "1":
                        if (!string.IsNullOrEmpty(choose))
                        {
                            result = "a";
                        }
                        else
                        {
                            result += "a";
                        }
                        choose = string.Empty;
                        break;
                    //ctrl-c
                    case "2":
                        if (!string.IsNullOrEmpty(choose))
                        {
                            copy = choose;
                        }
                        break;
                    //ctrl-x
                    case "3":
                        if (!string.IsNullOrEmpty(choose))
                        {
                            result = string.Empty;
                            copy = choose;
                            choose = string.Empty;
                        }
                        break;
                    //ctrl-v
                    case "4":
                        if (!string.IsNullOrEmpty(choose))
                        {
                            result = copy;
                            choose = string.Empty;
                        }
                        else
                        {
                            result += copy;
                        }
                        break;
                    //ctrl-a
                    case "5":
                        choose = result;
                        break;
                }

            }



            return result;
        }
    }
}
