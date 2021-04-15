using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DemoList
{
    class CircularList<T> : ICircularList<T>
    {
        Node<T> current; // текущий элемент списка
        int count;  // количество элементов в списке


        public T Current { get => current.Data; }

        public T Previous { get => current.Previus.Data; }

        public T Next { get => current.Next.Data; }

        public int Count {get => count;}

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Переход к следующему элементу
        /// </summary>
        public void MoveNext()
        {
            current = current.Next;
        }

        /// <summary>
        /// Переход к предыдущему элементу
        /// </summary>
        public void MoveBack()
        {
            current = current.Previus;
        }

        /// <summary>
        /// Текущий элемент всегда нулевой. Движение идет по MoveNext;
        /// Возвращает порядковый номер элемента в списке
        /// Возвращает -1, если элемент не найден
        /// </summary>
        /// <param name="item">Элемент, для которого необходимо вычислить индекс</param>
        /// <returns>индекс элемента</returns>
        public int IndexOf(T item)
        {
            Node<T> temp = current;
            for (int i = 0; i < count; i++)
            {
                if (temp.Data.Equals(item))
                {
                    return i;
                }
                temp = current.Next;
            }

            return -1;
        }

        /// <summary>
        /// Метод вставки по порядковому номеру, начиная с текущего
        /// У текущего элемента индекс 0.
        /// </summary>
        /// <param name="index">Порядковый номер элемента, начиная с текущего</param>
        /// <param name="item">Значение элемента списка</param>
        public void Insert(int index, T item)
        {
            Node<T> temp = current;
            for (int i = 0; i < index; i++) {
                temp = temp.Next;
            }
            Node<T> node = new Node<T>();
            node.Previus = temp;
            node.Next = temp.Next;
            temp.Next.Previus = node;
            temp.Next = node;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод добавления нового элемента в лист
        /// </summary>
        /// <param name="item"></param>

        public void Add(T item)
        {
            Node<T> node = new Node<T>();
            node.Data = item;

            // Если нет ни одного элемента в списке
            if (current == null)
            {
                // Циклим первый элемент на самом себе
                node.Previus = node;
                node.Next = node;
                current = node;

            }
            else
            {
                    node.Previus = current;
                    node.Next = current.Next;
                    current.Next.Previus = node;
                    current.Next = node;
            }
            count++;
        }

        /// <summary>
        /// Метод очистки листа
        /// Если удалить текущий элемент, то нельзя дойти до других
        /// </summary>
        public void Clear()
        {
            current = null;
            count = 0;
        }

        /// <summary>
        /// Метод проверки на наличие заданного элемента в списке
        /// </summary>
        /// <param name="item">Значение элемента списка</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            Node<T> tempCurrent = current;
            for (int i = 0; i < count; i++) {
                if (tempCurrent.Data.Equals(item))
                {
                    return true;
                }
                tempCurrent = tempCurrent.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод удаления элемента из списка
        /// Если в списке несколько одинаковых элементов, то удалится первый найденный после текущего
        /// Если удаляется текущий элемент, то current становится следующий за ним
        /// Возвращает true, если элемент был удален
        /// Возвращает false, если элемент не был удален
        /// </summary>
        /// <param name="item"> Элемент, который хотят удалить</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            Node <T> remove = current.Next;

            // Если элемент 1 в списке
            if (count == 1 && remove.Data.Equals(item))
            {
                current = null;
                count--;
                return true;
            }

            // Если удаляем текущий элемент
            if (current.Data.Equals(item))
            {
                remove.Previus.Next = remove.Next;
                remove.Next.Previus = remove.Previus;
                current = current.Next;
                count--;
                return true;
            }

            for (int i = 0; i < count; i++) {
                if (remove.Data.Equals(item)) {
                    remove.Previus.Next = remove.Next;
                    remove.Next.Previus = remove.Previus;
                    remove = null;
                    count--;
                    return true;
                }
                remove = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Реализация интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
