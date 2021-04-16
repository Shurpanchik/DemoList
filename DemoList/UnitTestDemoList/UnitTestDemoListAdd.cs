using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace UnitTestDemoList
{
    [TestClass]
    public class UnitTestDemoListAdd
    {
        /// <summary>
        /// Метод проверки добавления элементов в лист.
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            Assert.AreEqual(points.Contains(p1), true);
            Assert.AreEqual(points.Contains(p2), true);
            Assert.AreEqual(points.Contains(p3), true);
        }
    }
}
