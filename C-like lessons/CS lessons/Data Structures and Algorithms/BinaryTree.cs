using MiscUtil;
using System;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
    class BinaryTree<T>
    {
        public readonly int COUNT = 10;

        public Node _Root { get; private set; }

        public void Add(T Data)
        {
            if (_Root == null)
            {
                _Root = new Node(Data);
                return;
            }

            Node Current = _Root;
            bool Flag = true;
            while (true)
            {
                if (Operator.GreaterThan(Data, Current._Data))
                {
                    if (Current._pRight == null) { Current._pRight = new Node(Data); return; }
                    else Current = Current._pRight;
                }
                else if (Operator.LessThan(Data, Current._Data))
                {
                    if (Current._pLeft == null) { Current._pLeft = new Node(Data); return; }
                    else Current = Current._pLeft;
                }
                else throw new ArgumentException("There is already node with this number", 
                    nameof(Data));
            }
            throw new Exception("There was an error while adding new node");
        }

        #region CopiedPrint

        void print2DUtil(Node root, int space)
        {
            // Base case  
            if (root == null)
                return;

            // Increase distance between levels  
            space += COUNT;

            // Process right child first  
            print2DUtil(root._pRight, space);

            // Print current node after space  
            // count  
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root._Data + "\n");

            // Process left child  
            print2DUtil(root._pLeft, space);
        }

        // Wrapper over print2DUtil()  
        public void print2D(Node root)
        {
            // Pass initial space count as 0  
            print2DUtil(root, 0);
        }
        #endregion

        public Node Find(T Data)
        {
            Node Current = _Root;
            while (Current != null)
            {
                if (Operator.Equal(Current._Data, Data)) return Current;
                else Current = Operator.LessThan(Current._Data, Data) ? 
                        Current._pRight : Current._pLeft;
            }
            throw new Exception(message: "There wasn't such a node");
        }

        #region Traversals
        public void InorderTraversal(Node Current, dynamic Function)
        {
            if (Current._pLeft != null) _ = InorderTraversal(Current._pLeft, Function);
            if (Current != null) _ = Function(Current);
            if (Current._pRight != null) _ = InorderTraversal(Current._pRight, Function);
        }

        public void PreorderTraversal(Node Current, dynamic Function)
        {
            if (Current != null) _ = Function(Current);
            if (Current._pLeft != null) _ = InorderTraversal(Current._pLeft, Function);
            if (Current._pRight != null) _ = InorderTraversal(Current._pRight, Function);
        }

        public void PostorderTraversal(Node Current, dynamic Function)
        {
            if (Current._pLeft != null) _ = InorderTraversal(Current._pLeft, Function);
            if (Current._pRight != null) _ = InorderTraversal(Current._pRight, Function);
            if (Current != null) _ = Function(Current);
        }
        #endregion



        public class Node
        {
            public T _Data;
            internal Node _pLeft;
            internal Node _pRight;

            public Node(T Data)
            {
                _Data = Data;
            }
        }
    }
}
