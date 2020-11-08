namespace Data_Structures_and_Algorithms
{
    class CountList<T>
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
    }

    class CountListNode<T>
    {
        T _Data;
        CountListNode<T> pNext;

        public CountListNode(T data)
        {
            _Data = data;
        }
    }
}
