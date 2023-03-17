using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList;

namespace LLEnum
{
    internal class ListEnumerator<T> : IEnumerator<T>
    {
        Node<T> current;
        Node<T> next;
        Node<T> head;

        int index;
        int maxSize;

        public ListEnumerator(Node<T> head, int length)
        {
            this.head = head;
            maxSize = length;
            Reset();

        }

        T IEnumerator<T>.Current { get { return current.Content; } }

        object IEnumerator.Current { get { return current.Content; } }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index >= maxSize)
                return false;

            if (index == 0)
            {
                index++;
                return true;
            }

            if (next.Next != null)
            {
                Node<T> aux = next;
                next = next.Next;
                current = aux;
                index++;
                return true;
            }

            current = next;
            next = null;
            index++;
            return true;
        }

        public void Reset()
        {
            current = head;
            next = head.Next;
            index = 0;
        }

    }
}
