using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetConference2019
{
    public class AsyncIterators
    {
        public static async Task Demo()
        {
            foreach (var number in await GenerateSequence())
            {
                Console.WriteLine($"현재 시간은 {DateTime.Now:hh:mm:ss}. Retrieved { number}");
            }
        }

        internal static async Task<IEnumerable<int>> GenerateSequence()
        {
            var data = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                if (i % 10 == 0)
                    await Task.Delay(1000);

                data.Add(i);
            }

            return data;
        }

        internal static async IAsyncEnumerable<int> GenerateSequenceAsync()
        {
            for (int i = 0; i < 50; i++)
            {
                if (i % 10 == 0)
                    await Task.Delay(1000);

                yield return i;
            }
        }
    }
}
