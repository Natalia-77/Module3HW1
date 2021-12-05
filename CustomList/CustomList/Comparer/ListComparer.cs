using System.Collections.Generic;

namespace Module3HW1.Comparer
{
    public class ListComparer : IComparer<int>
    {
        public int Compare(int first, int second)
        {
            if (first > second)
            {
                return 1;
            }
            else if (first == second)
            {
                return 0;
            }

            return -1;
        }
    }
}
