using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DemoList
{
    public class CircularList<T> : ICircularList<T>
    {
        Node<T> current; // текущий элемент списка
        int count;  // количество элементов в списке


        public T Current { get => current.Data; }

        public T Previous { get => current.Previus.Data; }

        public T Next { get => current.Next.Data; }

        public int Count {get => count;}

        public bool IsReadOnly {get => false;}

        public T this[int index] { get => Search(index).Data; set => Insert(index, this[index]); }

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
                temp = temp.Next;
            }

            return -1;
        }

        /// <summary>
        /// Метод вставки по порядковому номеру, начиная с текущего
        /// У текущего элемента индекс 0.
        /// Если индекс больше длины списка, то ничего не добавляется
        /// </summary>
        /// <param name="index">Порядковый номер элемента, начиная с текущего</param>
        /// <param name="item">Значение элемента списка</param>
        public void Insert(int index, T item)
        {
            Node<T> temp = current;

            if (current == null && index == 0)
            {
                Add(item);
            }
            else
            {
                for (int i = 0; i <= count; i++)
                {
                    if (i == index)
                    {
                        Node<T> node = new Node<T>();
                        node.Data = item;

                        node.Previus = temp.Previus;
                        node.Next = temp;
                        temp.Previus.Next= node;  
                        temp.Previus = node;

                        count++;
                    }
                    temp = temp.Next;
                }
            }
        }

        /// <summary>
        /// Метод удаления элемента по порядковому номеру, начиная с текущего
        /// Текущий элемент имеет индекс 0
        /// Если удаляется текущий элемент, то current становится следующий за ним
        /// Если индекс строго больше длины массива, то ничего не удаляется
        /// </summary>
        public void RemoveAt(int index)
        {
           if(index == 0)
           {
                if (current != null)
                {
                    if (count == 1)
                    {
                        current = null;
                        count = 0;
                    }
                    else
                    {
                        current.Previus.Next = current.Next;
                        current.Next.Previus = current.Previus;
                        current = current.Next;
                        count--;
                    }
                }
           }
           else {
                Node<T> temp = current.Next;
                for(int i=1;i<count;i++)
                {
                    if(i==index){
                        temp.Previus.Next = temp.Next;
                        temp.Next.Previus = temp.Previus;
                        count--;
                        return;
                    }
                    temp = temp.Next;
                }
           }
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

        /// <summary>
        /// Метод копирования части массива в список,
        /// <summary>
        /// <param name="array"> Массив элементов</param>
        /// <param name="arrayIndex"> Индекс массива с которого начинается копирование</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            for(int i = arrayIndex; i<array.Length;i++)
            {
                Add(array[i]);
            }
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
            if (current == null) {
                return false;
            }
            Node <T> remove = current.Next;

            // Если элемент 1 в списке
            if (count == 1 && remove.Data.Equals(item))
            {
                current = null;
                count = 0;
                return true;
            }

            // Если удаляем текущий элемент
            if (current.Data.Equals(item))
            {
                current = current.Next;
                remove.Previus.Next = remove.Next;
                remove.Next.Previus = remove.Previus;
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

        /// <summary>
        /// Метод возвращающий итератор
        /// </summary>
         
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> temp = current;
            for(int i=0;i<count;i++)
            {
                yield return temp.Data;
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Реализация интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        /// <summary>
        /// Метод поиска элемента по порядковому номеруначиная с текущего
        /// Текущий элемент имеет индекс 0
        /// Если индекс строго больше длины массива, то ничего не найдется и вернется null
        /// </summary>
        public Node<T> Search(int index) {
            Node<T> node = current;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }
    }
}
