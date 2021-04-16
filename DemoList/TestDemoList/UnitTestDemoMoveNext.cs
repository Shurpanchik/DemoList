using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListMoveNext
    {
        /// <summary>
        /// Метод проверки перехода головы на следующий элемент
        /// </summary>
        [TestMethod]
        public void TestMoveNext()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Add(p1);
            points.MoveNext();
            points.Add(p2);
            points.MoveNext();
            points.Add(p3);
            points.MoveNext();

            points.MoveNext();
            Assert.AreEqual(points[0], p1);
            points.MoveNext();
            Assert.AreEqual(points[0], p2);
            points.MoveNext();
            Assert.AreEqual(points[0], p3);

        }
    }
}


