using System;
using Module3HW1.Collection;

namespace Module3HW1
{
   public class Starter
    {
        public void Run()
        {
            var list = new CustomList<int>();
            var rand = new Random();
            for (var i = 0; i < 4; i++)
            {
                list.Add(rand.Next(1, 20));
            }

            list.Add(98);
            var array = new int[] { 21, 88, 12 };
            list.AddRange(array);
            list.InsertAt(77, 3);
            list.RemoveAt(2);
            list.RemoveAt(3);
            list.RemoveAt(4);
            list.RemoveAt(2);
            list.Remove(12);
            list.Sort();
            PrintList(list);
        }

        public void PrintList<T>(CustomList<T> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
