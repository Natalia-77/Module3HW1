using System;
using Module3HW1.Collection;

namespace CustomList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomList<int> c = new CustomList<int>();

            for (var i = 1; i < 3; i++)
            {
                c.Add(i);
            }

            Dist(c);

            c.Add(98);
            Dist(c);
            var arry1 = new int[] { 4, 3, 2 };
            c.AddRange(arry1);
            Dist(c);

            c.InsertAt(77, 3);
            Dist(c);

            c.DeleteAt(2);
            Dist(c);

            // c.DeleteAt(3);
            // Dist(c);

            // c.DeleteAt(4);
            // Dist(c);
            // c.DeleteAt(2);
            // Dist(c);
            Console.WriteLine(c.Capacity);
        }

        public static void Dist<T>(CustomList<T> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
