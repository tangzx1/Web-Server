using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test66
    {
        public static void GetResult(string strPre, string strIn)
        {
            var tree = GetTree(strPre, strIn);
            LastShowNode(tree);
        }

        static TreeNode GetTree(string strPre, string strIn)
        {
            if (string.IsNullOrEmpty(strPre))
                return null;
            int index = strIn.IndexOf(strPre.First());
            string leftIn = strIn.Substring(0, index);
            string rightIn = strIn.Substring(index + 1);

            string leftPre = strPre.Substring(1, leftIn.Length);
            string rightPre = strPre[(1 + leftIn.Length)..];
            TreeNode treeNode = new()
            {
                NodeValue = strPre.First() + "",
                LeftNode = GetTree(leftPre, leftIn),
                RightNode = GetTree(rightPre, rightIn)
            };
            return treeNode;
        }

        static void LastShowNode(TreeNode node)
        {
            if (node is not null)
            {
                LastShowNode(node.LeftNode);
                LastShowNode(node.RightNode);
                Console.WriteLine(node.NodeValue);
            }
        }

    }
}
