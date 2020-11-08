using System.Collections;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
    class CountList<T> : IEnumerable<T>
    {
        CountListNode<T> _Head;

        public void Add(T Data)
        {
            if (_Head == null)
            {
                _Head = new CountListNode<T>(Data);
                return;
            }


        }

        public IEnumerator<T> GetEnumerator()
        {
            var Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            var Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }
    }

    class CountListNode<T>
    {
        public T _Data { get; set; }
        public CountListNode<T> _pNext { get; set; }

        public CountListNode(T data)
        {
            _Data = data;
        }
    }
}
