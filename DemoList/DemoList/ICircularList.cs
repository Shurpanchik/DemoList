using System;
using System.Collections.Generic;
using System.Text;

namespace DemoList
{
    public interface ICircularList<T> : IList<T>
    {
        void MoveNext();
        void MoveBack();
        T Current { get; }
        T Previous { get; }
        T Next { get; }
    }
}
