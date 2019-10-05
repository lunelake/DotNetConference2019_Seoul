using System;
using System.Collections.Generic;
using System.Text;

namespace NetConference2019
{
    public struct Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        readonly public double Distance => Math.Sqrt(X * X + Y * Y);

        readonly public override string ToString() => $"({X}, {Y}) is {Distance} from the origin.";

        public void Translate(int xOffset, int yOffset)
        {
            X += xOffset;
            Y += yOffset;
        }
    }

    public class ReadOnlyMembers
    {
        public static void Demo()
        {
            var p = new Point() { X = 30, Y = 40 };
            Console.WriteLine(p);
        }
    }
    
}
