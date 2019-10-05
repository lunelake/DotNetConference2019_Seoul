using System;
using System.Collections.Generic;
using System.Text;

namespace NetConference2019
{
    public class StaticLocalFunc
    {
        public static void Demo()
        {
            foreach (var i in Counter(1, 10)) Console.WriteLine(i);
        }

        public static IEnumerable<int> Counter(int start, int end)
        {
            if (start >= end) throw new ArgumentOutOfRangeException(nameof(start), "error");

            return localCounter(start, end);

            static IEnumerable<int> localCounter(int start, int end)
            {
                for (int i = start; i < end; i++)
                {
                    yield return i;
                }
            }
        }
    }
}
