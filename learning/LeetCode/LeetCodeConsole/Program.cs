// See https://aka.ms/new-console-template for more information
using LeetCodeConsole;

#region 1. 字符串分割
//string inputStr = "12abc-abCABc-4aB@";
//int inputNumber= 3;
//Console.WriteLine(StringSplit.SplitString(inputStr,inputNumber));
#endregion


#region 3. 统计射击比赛成绩
//int count = 13;
//List<int> ids = new()
//{
//    3,3,7,4,4,4,4,7,7,3,5,5,5
//};
//List<int> scores = new()
//{
//   53,80,68,24,39,76,66,16,100,55,53,80,55
//};
//Console.WriteLine(ScoreOrder.OrderMethod(count, ids, scores));
#endregion

#region 4. 字符串序列判定
//string s = "axc";
//string t = "ahbgdc";
//Console.WriteLine(Test4.IsChild(s, t));

#endregion

#region 5. 数据分类

//string str = "5 9 8 -1 -1 7 -1 -1 -1 -1 -1 6";
//Console.WriteLine(Test5.GetMinLeafNode(str));

#endregion

#region 6. 5键键盘的输出

//string str = "1 1 5 3 4 5 2 4 4";
//Console.WriteLine(Test6.GetResult(str));

#endregion

#region 7. 检查是否存在满足条件的数字组合

//string str = "2 7 3 0";
//Console.WriteLine(Test7.GetResult(str));

#endregion

#region 8. 数组拼接
//List<List<int>> list = new();
//list.Add(new List<int>() { 2, 5, 6, 7, 9, 5, 7 });
//list.Add(new List<int>() { 1, 7, 4, 3, 4 });
//list.Add(new List<int>() { 4, 5, 7, 1, 3, 8 });
//Console.WriteLine(Test8.GetResult(3, list));

#endregion

#region 10. 考勤信息
//string str = "present present present present leaveearly present late present present";
//Console.WriteLine(Test10.GetResult(str.Split(' ').ToList()));

#endregion

#region 14. 整数对最小和 ---第一题 勾股元组数
//int start = Convert.ToInt32(Console.ReadLine());
//int end = Convert.ToInt32(Console.ReadLine());
//Test14.GetResult1(start, end);
#endregion

#region 14. 整数对最小和 ---第四题  TLV解码
//string tagA = "31";
//string tagB = "32 01 00 AE 90 02 00 01 02 30 03 00 AB 32 31 31 02 00 32 33 33 01 00 CC";
//Test14.GetResult4(tagA, tagB);
#endregion

#region 14. 整数对最小和 ---第五题  猴子跳台阶 1级和3级（递归的循环写法）
//int step = Convert.ToInt32(Console.ReadLine());
//Test14.GetResult5(step);
#endregion

#region 28. 二叉树遍历
//string input = "a{b{d,e{g,h{,I}}},c{f}}";
//Test28.GetResult(input);
#endregion

#region 66. 二叉树的广度优先遍历
//string strPre = "DBACEGF";
//string strIn = "ABCDEFG";
//Test66.GetResult(strPre, strIn);
#endregion



#region HJ16 购物单
//using LeetCodeConsole.HJTest;
//string line;
//int lineNumber = 0;
//int money = 0;
//int count = 0;
//List<HJ16Goods> goods = new List<HJ16Goods>();

//while ((line = Console.ReadLine()) != null)
//{ // 注意 while 处理多个 case
//    if (string.IsNullOrWhiteSpace(line))
//    {
//        break;
//    }
//    if (lineNumber == 0)
//    {
//        List<int> list = line.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
//        money = list[0];
//        count = list[1];
//    }
//    else
//    {
//        List<int> list = line.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
//        goods.Add(new HJ16Goods()
//        {
//            V = list[0],
//            P = list[1] * list[0],
//            Q = list[2]
//        });
//    }
//    lineNumber++;
//}
//Console.WriteLine(HJTest16.GetResult(money, count, goods));
#endregion

#region HJ24 合唱队
int count = int.Parse(System.Console.ReadLine());
List<int> numbers= System.Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToList();


System.Console.WriteLine();

#endregion



