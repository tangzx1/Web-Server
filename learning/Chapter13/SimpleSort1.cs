using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter13
{
    public class SimpleSort1
    {
        public static List<int> BubbleSort(List<int> items, SortType sortOrder)
        {
            int i;
            int j;
            int temp;

            if (items is null)
            {
                return new List<int>();
            }

            for (i = items.Count - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    bool swap = false;
                    switch (sortOrder)
                    {
                        case SortType.Asc:
                            swap = items[j - 1] > items[j];
                            break;
                        case SortType.Desc:
                            swap = items[j - 1] < items[j];
                            break;
                    }
                    if (swap)
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
            return items;
        }

        public static List<int> BubbleSort(List<int> items, Func<int, int, bool> compare)
        {
            int i;
            int j;
            int temp;

            if (items is null)
            {
                return new List<int>();
            }
            if (compare is null)
            {
                throw new NotImplementedException();
            }

            for (i = items.Count - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (compare(items[j - 1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
            return items;
        }

        public static bool GreaterThan(int first, int second)
        {
            return first > second;
        }

    }
}
