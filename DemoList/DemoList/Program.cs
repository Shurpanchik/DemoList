using System;

namespace DemoList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CircularList<Point> points = new CircularList<Point>();
            points.Add(new Point(1, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(3, 3));
            
            for (int i = 0; i < points.Count; i++)
            {                
                Console.WriteLine(points.Current.X + " " + points.Current.Y + " ");
                points.MoveNext();
            }
            Console.Read();
        }
    }
}