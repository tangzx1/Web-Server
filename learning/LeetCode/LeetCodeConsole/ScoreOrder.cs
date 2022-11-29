using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsole
{
    internal class ScoreOrder
    {
        public static string OrderMethod(int count, List<int> ids, List<int> scores)
        {
            Dictionary<int, List<int>> dics = new();

            for (int i = 0; i < count; i++)
            {
                if (!dics.ContainsKey(ids[i]))
                {
                    dics.Add(ids[i], new List<int>() { scores[i] });
                }
                else
                {
                    dics.TryGetValue(ids[i], out List<int> score);
                    score.Add(scores[i]);
                }
            }
            List<UserScore> users = new();
            foreach (var pair in dics)
            {
                if (pair.Value.Count > 2)
                {
                    var orders = pair.Value.OrderByDescending(x => x).ToList();
                    users.Add(new UserScore()
                    {
                        Id = pair.Key,
                        Score = orders[0] + orders[1] + orders[2]
                    });
                }
            }

            var desc = users.OrderByDescending(x => x.Score).ThenByDescending(x => x.Id).ToList();

            return string.Join(',', desc.Select(x => x.Id));
        }



    }

    public class UserScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
}
