using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListInsert
    {
        /// <summary>
        /// Метод проверки добавления элементов в лист.
        /// </summary>
        [TestMethod]
        public void TestInsert()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Insert(0,p1);
            points.Insert(1,p3);
            points.Insert(1,p2);

            // цепочка 1-2-3

            Assert.AreEqual(points[0], p1);
            Assert.AreEqual(points[1], p2);
            Assert.AreEqual(points[2], p3);
        }

    }
}


