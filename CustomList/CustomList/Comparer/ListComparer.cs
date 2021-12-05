using System.Collections.Generic;

namespace Module3HW1.Comparer
{
    public class ListComparer<T> : IComparer<T>
    {
        public int Compare(T first, T second)
        {
            if (first.GetHashCode() > second.GetHashCode())
            {
                return 1;
            }
            else if (first.GetHashCode() == second.GetHashCode())
            {
                return 0;
            }

            return -1;
        }
    }
}
