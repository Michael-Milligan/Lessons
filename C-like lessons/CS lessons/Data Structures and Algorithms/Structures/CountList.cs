using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_and_Algorithms.Structures
{
    public class CountList<T> : IEnumerable<T>
    {
        public Node<T> _Head { get; set; }
        public SortDelegate _SortMethod { get; private set; }
        public delegate void SortDelegate(Node<T> Head);

        public void Add(T Data)
        {
            _ = Data ?? throw new ArgumentNullException(nameof(Data));

            if (_Head == null)
            {
                _Head = new Node<T>(Data);
                return;
            }

            Node<T> Current = _Head;
            while (Current._pNext != null)
            {
                Current = Current._pNext;
            }

            Current._pNext = new Node<T>(Data);
        }

        public Node<T> GetElement(T Data)
        {
            _ = Data ?? throw new ArgumentNullException(nameof(Data));

            Node<T> Current = _Head;
            while (Current == null && 
                EqualityComparer<T>.Default.Equals(Current._Data, Data))
            {
                Current = Current._pNext;
            }
            _ = Current ?? throw new Exception("No such an element");
            ++Current._Count;

            _SortMethod(_Head);

            return Current;
        }

        public CountList(SortDelegate SortMethod)
        {
            _Head = null;
            _SortMethod = SortMethod;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            Node<T> Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }

        public class Node<T>
        {
            public T _Data { get; set; }
            public int _Count { get; set; }
            public Node<T> _pNext { get; set; }

            public Node(T data)
            {
                _Data = data;
                _Count = 0;
            }

        }
    }

    
}
