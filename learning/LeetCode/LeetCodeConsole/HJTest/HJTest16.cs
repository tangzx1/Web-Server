using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole.HJTest
{
    internal class HJTest16
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">预算</param>
        /// <param name="m">可购买的物品的个数</param>
        /// <param name="goods"></param>
        /// <returns></returns>
        public static int GetResult(int n, int m, List<HJ16Goods> goods)
        {
            foreach (var item in goods)
            {
                if (item.Q > 0)
                {
                    if (goods[item.Q - 1].A1 == null)
                    {
                        goods[item.Q - 1].A1 = item;
                    }

                }
            }

            var todoGoods = goods.Where(x => x.Q == 0).ToList();
            int counts = todoGoods.Count();

            bool flag = true;
            int[,] result = new int[m, n];

            //数量
            for (int i = 1; i <= m; i++)
            {
                //预算
                for (int j = 1; j <= n; j++)
                {
                    result[i, j] = result[i - 1, j];
                    if (i <= counts)
                    {
                        if (j >= todoGoods[i - 1].V)
                        {
                            result[i, j] = Math.Max(result[i, j], result[i - 1, j - todoGoods[i - 1].V] + todoGoods[i - 1].P);
                        }
                        if (todoGoods[i - 1].A1 != null && j >= todoGoods[i - 1].V + todoGoods[i - 1].A1.V)
                        {
                            result[i, j] = Math.Max(result[i, j], result[i - 1, j - todoGoods[i - 1].V - todoGoods[i - 1].A1.V] + todoGoods[i - 1].P + todoGoods[i - 1].A1.P);
                        }
                        if (todoGoods[i - 1].A2 != null && j >= todoGoods[i - 1].V + todoGoods[i - 1].A2.V)
                        {
                            result[i, j] = Math.Max(result[i, j], result[i - 1, j - todoGoods[i - 1].V - todoGoods[i - 1].A2.V] + todoGoods[i - 1].P + todoGoods[i - 1].A2.P);
                        }
                        if (todoGoods[i - 1].A2 != null&&todoGoods[i - 1].A2 != null && j >= todoGoods[i - 1].V + todoGoods[i - 1].A1.V + todoGoods[i - 1].A2.V)
                        {
                            result[i, j] = Math.Max(result[i, j], result[i - 1, j - todoGoods[i - 1].V - todoGoods[i - 1].A1.V - todoGoods[i - 1].A2.V] + todoGoods[i - 1].P + todoGoods[i - 1].A1.P + todoGoods[i - 1].A2.P);
                        }

                    }



                }
            }
            return result[m, n];
        }

    }

    public class HJ16Goods
    {
        /// <summary>
        /// 价格
        /// </summary>
        public int V { get; set; }
        /// <summary>
        /// 物品的重要度
        /// </summary>
        public int P { get; set; }
        /// <summary>
        /// 该物品是主件还是附件
        /// 如果 q=0 ，表示该物品为主件，如果 q>0 ，表示该物品为附件， q 是所属主件的编号
        /// </summary>
        public int Q { get; set; }

        public HJ16Goods A1 { get; set; }
        public HJ16Goods A2 { get; set; }
    }

}
