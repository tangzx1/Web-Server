using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class Test28
    {
        public static void GetResult(string input)
        {
            TreeNode root = new();
            TreeNode temp = root;
            Stack<TreeNode> stack = new();
            stack.Push(root);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' && input[i + 1] != ',' && input[i - 1] != ',')
                {
                    var node = new TreeNode();
                    temp.LeftNode = node;
                    temp = node;
                    stack.Push(node);
                }
                else if (input[i] == '{' && input[i + 1] == ',')
                {
                    i++;
                    var node = new TreeNode();
                    temp.RightNode = node;
                    temp = node;
                    stack.Push(node);
                }
                else if (input[i] == ',')
                {
                    var node = new TreeNode();
                    temp.RightNode = node;
                    temp = node;
                    stack.Push(node);
                }
                else if (input[i] != '{' && input[i] != '}' && input[i] != ',')
                {
                    temp.NodeValue = input[i] + "";
                }
                else if (input[i] == '}')
                {
                    stack.Pop();
                    temp = stack.Peek();
                }

            }
            ShowNode(root);

        }


        static void ShowNode(TreeNode node)
        {
            if (node is not null)
            {
                ShowNode(node.LeftNode);
                Console.WriteLine(node.NodeValue);
                ShowNode(node.RightNode);
            }
        }
    }

    public class TreeNode
    {
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }
        public string NodeValue { get; set; }
    }
}
