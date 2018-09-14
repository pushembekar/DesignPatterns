using System;

namespace PrototypeCodeingExercise
{
    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line { Start = new Point { X = this.Start.X, Y = this.Start.Y }, End = new Point { X = this.End.X, Y = this.End.Y } };
        }

        public override string ToString()
        {
            return $"Line: StartX = {this.Start.X}, StartY = {this.Start.Y}, EndX = {this.End.X}, EndY = {this.End.Y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var line1 = new Line { Start = new Point { X = 4, Y = 4 }, End = new Point { X = 3, Y = 3 } };
            Console.WriteLine(line1);
            var line2 = line1.DeepCopy();
            line2.Start.X = 6;
            Console.WriteLine(line2);
        }
    }
}
