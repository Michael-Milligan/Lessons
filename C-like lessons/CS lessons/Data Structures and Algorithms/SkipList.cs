using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_and_Algorithms
{
    public class SkipList<T> //: IEnumerable<T>
    {
        public int _MaxLevel { get; private set; }
        public Node<T> _Head { get; private set; }
        public int _NodesNumber { get; private set; }

        public SkipList(int MaxLevel)
        {
            _MaxLevel = MaxLevel;
            _Head = new Node<T>(this);
            _NodesNumber = 0;
        }

        public void Add(T Data)
        {
            Node<T>[] Current = new Node<T>[_MaxLevel];
            for (int i = 0; i < Current.Length; ++i)
                Current[i] = _Head;

            Node<T> New = new Node<T>(this, Data);
            if (_NodesNumber == 0)
            {
                _Head._Data = Data;
                ++_NodesNumber;
                return;
            }

            Node<T> ToFind = new Node<T>(this);
            try
            {
                Find(default, out ToFind);
            }
            catch (Exception) { }
            
            if (ToFind._Pointers.Where(item => item != null).Count() != 0 && EqualityComparer<T>.Default.Equals(ToFind._Data, default))
            {
                ToFind._Data = Data;
                return;
            }


            for (int j = 1; j <= _MaxLevel; ++j)
            {
                while (Current[^j]._Pointers[^j] != null)
                    Current[^j] = Current[^j]._Pointers[^j];
            }

            ++_NodesNumber;
            double HighLevelFrequency = _MaxLevel != 2 ? (_MaxLevel - 2) * 4 : 2;
            double OrderNumber = _NodesNumber > HighLevelFrequency ? 
                (_NodesNumber % HighLevelFrequency) - 1 : _NodesNumber - 1;
            if (OrderNumber == 0) Current[^1]._Pointers[^1] = New;
            if (OrderNumber == HighLevelFrequency / 2) Current[^2]._Pointers[^2] = New;      

            for (int j = Current.Length - 3, k = _MaxLevel - 3; j >= 1; --j, --k)
            {
                if (OrderNumber < HighLevelFrequency / 2)
                {
                    if (OrderNumber == (j + k))
                        Current[j]._Pointers[j] = New;
                }
                else
                {
                    if (OrderNumber == (HighLevelFrequency - (j + k)))
                        Current[j]._Pointers[j] = New;
                }

            }
            Current[0]._Pointers[0] = New;
        }

        /// <summary>
        /// Deletes the info in found node, making it available for usage again
        /// </summary>
        /// <param name="Data: ">The data to delete node with</param>
        public void Delete(T Data)
        {
            Find(Data, out Node<T> ToDelete);
            ToDelete._Data = default;
        }

        /// <summary>
        /// Tries to find a node. If it wasn't there throws an exception
        /// </summary>
        /// <param name="Data: ">The data with which the node must be found</param>
        /// <param name="ToFind">The node to assign result to</param>
        public void Find(T Data, out Node<T> ToFind)
        {
            for (int i = _MaxLevel - 1; i >= 0; --i)
            {
                Node<T> Current = _Head;
                while (Current._Pointers[i] != null)
                {
                    if (EqualityComparer<T>.Default.Equals(Current._Data, Data))
                    { 
                        ToFind = Current;
                        return;
                    }
                    else Current = Current._Pointers[i];
                }
            }
            throw new Exception("There wasn't such a node");
        }

        public void PrintList()
        {
            for (int i = _MaxLevel - 1; i >= 0; --i)
            {
                Node<T> Current = _Head;
                while (Current != null)
                {
                    Console.Write(Current._Data + "\t");
                    Current = Current._Pointers[i];
                }
                Console.WriteLine();
            }
        }
    }

    public class Node<T>
    {
        public T _Data { get; set; }
        public Node<T>[] _Pointers { get; private set; }
        public Node(SkipList<T> Outer, T Data = default)
        {
            _Data = Data;
            _Pointers = new Node<T>[Outer._MaxLevel];
        }
    }
}
