using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDV
{
    public class DoubleLinkedList<T> : IEnumerable<T> where T: IComparable
    {
        private Node<T> head,tail;
        private int Length = 0;

        public void InsertAtStart(T value) {
            Node<T> node = new Node<T>();
            node.value = value;
            if (Length == 0)
            {
                head = node;
                tail = node;
            }
            else {
                node.next = head;
                head.prev = node;
                head = node;
            }
            Length++;
        }

        public void InsertAtEnd(T value) {
            Node<T> node = new Node<T>();
            node.value = value;
            if (Length == 0)
            {
                head = node;
                tail = node;
            }
            else {
                tail.next = node;
                node.prev = tail;
                tail = node;
            }
            Length++;
        }    
        
        public void InsertAfter(Node<T> prev_node, T value) {

            if (prev_node == null) {
                return;
            }

            Node<T> new_node = new Node<T>();
            new_node.value = value;
            new_node.next = prev_node.next;
            prev_node.next = new_node;
            new_node.prev = prev_node;

            if (new_node.next != null) {
                new_node.next.prev = new_node;
            }
            Length++;
        }

        public void Insert(T value, int Position){
            Node<T> node = new Node<T>();
            node.value = value;
            if (Length == 0)
            {
                head = node;
                tail = node;
                Length++;
            }
            else
            {
                if (Position == 0)
                {
                    InsertAtStart(value);
                }
                else if (Position >= Length)
                {
                    InsertAtEnd(value);
                }
                else
                {
                    Node<T> pretemp = head;
                    int cont = 0;
                    while (cont < Position - 1)
                    {
                        pretemp = pretemp.next;
                        cont++;
                    }
                    node.next = pretemp.next;
                    pretemp.next.prev = node;
                    pretemp.next = node;
                    node.prev = pretemp;
                    Length++;
                }
            }
        }

        void DeleteAtStart() {
            if (Length > 0) {
                if (Length == 1)
                {
                    head = null;
                    tail = null;
                }
                else {
                    head = head.next;
                    head.prev = null;
                }
                Length--;
            }
        }

        void DeleteAtEnd() {
            if (Length > 0)
            {
                if (Length == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                Length--;
            }
        }

        public void Delete(int position) {
            if (Length > 0)
            {
                if (Length == 1)
                {
                    head = null;
                    tail = null;
                    Length--;
                }
                else {
                    if (position == 0) {
                        DeleteAtStart();
                    }
                    else if (position >= Length -1) {
                        DeleteAtEnd();
                    }
                    else {
                        Node<T> prev = head;
                        Node<T> node = head.next;
                        int cont = 0;
                        while (cont < position - 1) {
                            prev = node;
                            node = node.next;
                            cont++;
                        }
                        prev.next = node.next;
                        if (node.next != null)
                        {
                            node.next.prev = prev;
                        }
                        Length--;
                    }
                }
            }
        }

    }
}
