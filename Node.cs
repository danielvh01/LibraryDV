using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDV
{
    public class Node<T> where T : IComparable
    {
        public Node<T> next = null;
        public Node<T> prev = null;
        public T value;
        public Node(T value = default)
        {
            
        }
    }
}
