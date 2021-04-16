using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListEnumerator
    {
        /// <summary>
        /// Проверка наличия перечислителя в коллекции
        /// </summary>
        [TestMethod]
        public void TestEnumerator()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            foreach (Point p in points)
            {
                Assert.AreEqual(points.Contains(p), true);
            }
        }
    }
}


