using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetConference2019
{
    public class IndicesAndRanges
    {
        private static string[] words =
        {                  // index from start   index from end
            "The",         // 0                  ^9
            "Quick",       // 1                  ^8
            "brown",       // 2                  ^7
            "fox",         // 3                  ^6
            "jumped",      // 4                  ^5
            "over",        // 5                  ^4
            "the",         // 6                  ^3
            "lazy",        // 7                  ^2
            "dog"          // 8                  ^1
        };

        public static void Demo1()
        {
            Console.WriteLine(words[^1]);
        }

        public static void Demo2()
        {
            var lazyDog = words[^2..^0];
            foreach (var word in lazyDog) Console.WriteLine($"<{word}>");
            Console.WriteLine();
        }

        public static void Demo3()
        {
            var allWords = words[..];
            var firstPhrase = words[..4];
            var lastPhrase = words[6..];

            foreach (var word in allWords) Console.Write($"<{word}>");
            Console.WriteLine();
            foreach (var word in firstPhrase) Console.Write($"<{word}>");
            Console.WriteLine();
            foreach (var word in lastPhrase) Console.Write($"<{word}>");
            Console.WriteLine();
        }

        public static void Demo4()
        {
            Index the = ^3;
            Console.WriteLine(words[the]);

            Range phrase = 1..4;
            var text = words[phrase];
            foreach (var word in text) Console.Write($"<{word}>");
            Console.WriteLine();
        }

        public static void Demo5()
        {
            var numbers = Enumerable.Range(0, 100).ToArray();
            int x = 12;
            int y = 25;
            int z = 36;

            Console.WriteLine($"{numbers[^x]}은 {numbers[numbers.Length - x]}와 같습니다.");
            Console.WriteLine($"{numbers[x..y].Length}은 {numbers[y - x]}와 같습니다.");

        }

        public static void Demo6()
        {
            int[] sequence = Enumerable.Range(0, 1000).Select(x => (int)(Math.Sqrt(x) * 100)).ToArray();

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = start..(start + 10);
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}: \tMin: {min} \tMax: {max}, \tAverage:{average}");
            }

            for (int start = 0; start < sequence.Length; start += 100)
            {
                Range r = ^(start + 10)..^start;
                var (min, max, average) = MovingAverage(sequence, r);
                Console.WriteLine($"From {r.Start} to {r.End}: \tMin: {min} \tMax: {max}, \tAverage:{average}");
            }

            (int min, int max, double average) MovingAverage(int[] subSequence, Range range) =>
               (
                    subSequence[range].Min(),
                    subSequence[range].Max(),
                    subSequence[range].Average()
               );
        }

    }
}
