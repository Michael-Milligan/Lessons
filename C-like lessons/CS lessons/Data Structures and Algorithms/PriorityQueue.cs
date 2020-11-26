using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures_and_Algorithms
{
    class PriorityQueue<T> : IEnumerable<T>
    {
        QueueNode _Head;

        public void Add(T Data, int Priority)
        {
            if (_Head == null)
            {
                _Head = new QueueNode(Data, Priority);
                return;
            }
            QueueNode Current = _Head;
            while (Current._pNext != null)
            {
                Current = Current._pNext;
            }
            Current._pNext = new QueueNode(Data, Priority);
        }

        public IEnumerator<T> GetEnumerator()
        {
            QueueNode Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            QueueNode Current = _Head;
            while (Current != null)
            {
                yield return Current._Data;
                Current = Current._pNext;
            }
        }

        public QueueNode GetTop()
        {
            QueueNode Current = _Head;
            int Priority = MaxPriority();
            for (int i = Priority; i >= 0; ++i)
            {
                Current = _Head;
                while (Current != null)
                {
                    if (Current._Priority == i) return Current;
                    Current = Current._pNext;
                }
            }
            throw new Exception("There wasn't such an element");
        }

        public T PopTop()
        {
            QueueNode Current = GetTop();
            T Data = Current._Data;

            QueueNode New = _Head;
            while (New._pNext != Current)
            {
                New = New._pNext;
            }
            New._pNext = New._pNext._pNext;

            return Data;
        }

        private int MaxPriority()
        {
            List<int> Priorities = new List<int>();
            QueueNode Current = _Head;
            while (Current != null)
            {
                Priorities.Add(Current._Priority);
                Current = Current._pNext;
            }
            return Priorities.Max();
        }

        public class QueueNode
        {
            public T _Data { get; set; }
            public int _Priority { get; init; }
            public QueueNode _pNext { get; set; }

            public QueueNode(T Data, int Priority)
            {
                _Data = Data;
                _Priority = Priority;
            }
        }
    }
}
