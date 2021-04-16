using System;
using System.Collections.Generic;
using System.Text;

namespace DemoList
{
   public class Node <T>
    {
        T data;
        Node <T> previus;
        Node <T> next;

        public T Data { get => data; set => data = value; }
        internal Node<T> Previus { get => previus; set => previus = value; }
        internal Node<T> Next { get => next; set => next = value; }
    }
}
