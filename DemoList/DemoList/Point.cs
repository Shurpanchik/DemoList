using System;
using System.Collections.Generic;
using System.Text;

namespace DemoList
{
    /// <summary>
    /// Класс точек, создан для иллюстрации работы со списком
    /// </summary>
    class Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
