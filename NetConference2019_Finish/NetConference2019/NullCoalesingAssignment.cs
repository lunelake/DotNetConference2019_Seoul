using System;
using System.Collections.Generic;
using System.Text;

namespace NetConference2019
{
    public class NullCoalesingAssignment
    {
        public static void Demo()
        {
            List<int>? numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ?? 17);
            numbers.Add(i ?? 20);

            Console.WriteLine(string.Join(' ', numbers));
            Console.WriteLine();
        }
    }
}
