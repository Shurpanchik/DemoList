using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoList;

namespace TestDemoList
{
    [TestClass]
    public class UnitTestDemoListRemoveAT
    {
        /// <summary>
        /// ����� �������� �������� �� �������
        /// </summary>
        [TestMethod]
        public void TestRemoveAt()
        {
            CircularList<Point> points = new CircularList<Point>();
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(3, 3);  
            points.Insert(0,p1);
            points.Insert(1,p2);
            points.Insert(2,p3);


            //�������� �������� � ��������
            points.RemoveAt(1);
            Assert.AreEqual(points[1], p3);

            // �������� �������� � ������
            points.RemoveAt(0);
            Assert.AreEqual(points[0], p3);

            //�������� �������� ���������� ��������
            points.RemoveAt(0);
            Assert.AreEqual(points.Count, 0);

            //�������� �������� �� ������������� �������
            points.RemoveAt(0);
            Assert.AreEqual(points.Count, 0);

            //�������� �������� �� ������������� �������
            points.Insert(0, p1);
            points.RemoveAt(1);
            Assert.AreEqual(points.Count, 1);
        }
    }
}


