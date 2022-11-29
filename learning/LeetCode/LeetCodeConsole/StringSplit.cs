using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class StringSplit
    {
        public static string SplitString(string inputStr, int inputNumber)
        {
            List<string> strings = inputStr.Split('-').ToList();
            int firstIndex = inputStr.IndexOf("-");
            if (firstIndex != -1)
            {
                string firstStr = inputStr[..firstIndex];
                string elseStr = inputStr.Substring(firstIndex).Replace("-", "");
                string returnStr = firstStr;
                if (inputNumber > 0)
                {
                    int count = elseStr.Length / inputNumber;
                    int lastCount = elseStr.Length % inputNumber;
                    string todoStr = string.Empty;
                    for (int i = 0; i < count; i++)
                    {
                        todoStr = elseStr.Substring(i * inputNumber, inputNumber);
                        returnStr += "-" + TransformString(todoStr);
                    }

                    returnStr += "-" + elseStr[(count * inputNumber)..];

                }
                return returnStr;

            }
            else
                return inputStr;

        }

        static string TransformString(string inputStr)
        {
            int upperCount = 0;
            int lowerCount = 0;
            foreach (var item in inputStr)
            {
                if (item >= 'A' && item <= 'Z')
                {
                    upperCount++;
                }
                if (item >= 'a' && item <= 'z')
                {
                    lowerCount++;
                }
            }
            if (upperCount > lowerCount)
            {
                return inputStr.ToUpper();
            }
            else
            {
                if (upperCount == lowerCount)
                {
                    return inputStr;
                }
                return inputStr.ToLower();
            }


        }

    }
}
