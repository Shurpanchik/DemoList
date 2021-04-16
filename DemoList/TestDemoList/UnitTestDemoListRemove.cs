using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListRemove
    {
        /// <summary>
        /// Метод проверки удаления существующих элементов
        /// </summary>
        [TestMethod]
        public void TestRemovePositiveTest()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Insert(0, p1);
            points.Insert(1, p2);
            points.Insert(2, p3);


            //Проверка удаления с середины
            Assert.AreEqual(points.Remove(p2), true);
            Assert.AreEqual(points[1], p3);

            
            // Проверка удаления с головы
            Assert.AreEqual(points.Remove(p1), true);
            Assert.AreEqual(points[0], p3);

            //Проверка удаления последнего элемента
            Assert.AreEqual(points.Remove(p3), true);
            Assert.AreEqual(points.Count, 0);
            
        }

        /// <summary>
        /// Метод проверки удаления не существующих элементов
        /// </summary>

        [TestMethod]
        public void TestRemoveNegativeTest()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            Point p4 = new Point(4, 4);

            //Проверка удаления не существующего элемента в пустом списке
            Assert.AreEqual(points.Remove(p3), false);

            points.Insert(0, p1);

            //Проверка удаления не существующего элемента в списке длиной 1
            Assert.AreEqual(points.Remove(p3), false);

            points.Insert(1, p2);

            //Проверка удаления не существующего элемента в списке длиной 2
            Assert.AreEqual(points.Remove(p3), false);

            points.Insert(2, p3);

            //Проверка удаления не существующего элемента в списке длиной 3
            Assert.AreEqual(points.Remove(p3), false);
        }
    }
}


