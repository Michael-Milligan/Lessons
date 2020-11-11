using System;
using System.Collections;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
    public class CountList<T> : IEnumerable<T>
    {
        Node<T> _Head;

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

        class Node<T>
        {
            public T _Data { get; set; }
            public Node<T> _pNext { get; set; }

            public Node(T data)
            {
                _Data = data;
            }

        }
    }

    
}
