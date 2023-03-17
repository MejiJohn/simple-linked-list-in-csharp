using LLEnum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLinkedList
{
    /**
     * A simple implementation of a LinkedList.
     * By Enol Meji Gavela.
     */
    public class List<T>: IEnumerable<T>
    {
        private Node<T> head;
        private int NumberOfElements { get; set; }
        
        /*
         * Auxiliar: Adds an element as head,
         */
        public void AddAsHead(T content)
        {
            Node<T> nodeToAdd = new Node<T>(content);
            nodeToAdd.Next = head;
            head = nodeToAdd;
            NumberOfElements++;
        }

        /*
         * Auxiliar: Returns the last node.
         */
        private Node<T> GetLastNode()
        {
            Node<T> aux = head;
            while (aux.Next != null)
            {
                aux = aux.Next;
            }
            return aux;
        }

        /**
         * Returns the element in the tail of the structure
         */
        public T GetLastElement()
        {
            return GetLastNode().Content;
        }

        private Node<T> GetNode(int pos)
        {
            Node<T> aux = head;
            uint count = 0;

            while (count < pos)
            {
                aux = aux.Next;
                count++;
            }

            return aux;

        }

        /*
         * Get the element by position.
         */
        public T GetElement(int pos)
        {
            if(pos < 0 || pos >= NumberOfElements)
            {
                return default(T);
            }

            return GetNode(pos).Content;
        }

        /*
         * Adds an element in the tail of the list.
         */
        public void Add(T content)
        {
            Node<T> nodeToAdd = new Node<T>(content);

            if(head == null)
            {
                head = nodeToAdd;
                NumberOfElements++;
                return;
            }

            Node<T> lastNode = GetLastNode();
            lastNode.Next = nodeToAdd;
            NumberOfElements++;
        }

        /**
         * Removes element by position
         */
        public bool Remove(int pos)
        {
            if (head == null || pos >= NumberOfElements)
            {
                return false;
            }

            if(pos == 0)
            {
                head = head.Next;
                NumberOfElements--;
                return true;
            }

            Node<T> nodeToRemove;
            Node<T> previous = head;

            for (int i = 0; i < pos - 1; i++)
            {
                previous = previous.Next;
            }

            nodeToRemove = previous.Next;
            previous.Next = nodeToRemove.Next;

            NumberOfElements--;

            return true;

        }

        /*
         * Removes an element.
         */
        public void RemoveElement(T element)
        {
            Node<T> previous = null;
            Node<T> aux = head;

            if(aux != null && aux.Content.Equals(element))
            {
                head = aux.Next;
                NumberOfElements--;
                return;
            }

            while(aux != null && !aux.Content.Equals(element))
            {
                previous = aux;
                aux = aux.Next;
            }

            if(aux == null)
            {
                return;
            }

            previous.Next = aux.Next;
            NumberOfElements--;
            
        }

        /*
         * Returns the number of elements
         */
        public int Size()
        {
            return NumberOfElements;
        }

        /*
         * Returns "true" in the element is present in the structure.
         */
        public Boolean Contains(T element)
        {
            for(int i=0; i<NumberOfElements; i++)
            {
                if(GetElement(i).Equals(element)) return true;
            }

            return false;
        }

        /*
         * toString() method for testing (obsolete).
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0;i<Size(); i++)
            {
                if(i == 0)
                {
                    sb.Append("["+ GetElement(i) + ", ");
                }

                else if(i == Size()-1 )
                {
                    sb.Append(GetElement(i) + "]");
                }

                else
                {
                    sb.Append(GetElement(i) + ", ");
                }
                
            }

            return sb.ToString();
        }

        /*
         * Enumerator.
         */
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(head, Size());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator<T>(head, Size());
        }

        
    }

    /*
     * Represents a node in the structure.
     */
    internal class Node<T>
    {
        internal T Content { get; set; }
        internal Node<T> Next { get; set; }

        public Node(T content)
        {
            this.Content = content;
            Next = null;
        }
    }

}
