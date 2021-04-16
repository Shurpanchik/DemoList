using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListIndexOf
    {
        /// <summary>
        /// ���������� ����, ������� ���� � ������.
        /// </summary>
        [TestMethod]
        public void TestIndexOfFindElement()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            //������� 1-3-2 

            Assert.AreEqual(points.IndexOf(p1), 0);
            Assert.AreEqual(points.IndexOf(p3), 1);
            Assert.AreEqual(points.IndexOf(p2), 2);
            

        }

        /// <summary>
        /// ���������� ����, �������� ��� � ������.
        /// </summary>
        [TestMethod]
        public void TestIndexOfNoFindElement()
        {
            CircularList<Point> points = new CircularList<Point>();
           
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);
            Point p4 = new Point(4, 4);

            // ������� �� ������ � ����� ������
            Assert.AreEqual(points.IndexOf(p1), -1);

            points.Add(p1);

            // ������� �� ������ � ������ �� 1 ��������
            Assert.AreEqual(points.IndexOf(p4), -1);

            points.Add(p2);
            points.Add(p3);

            // ������� �� ������ � ������ � ������ ������ 1
            Assert.AreEqual(points.IndexOf(p4), -1);
        }
    }
}


