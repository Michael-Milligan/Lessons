using System;

namespace Neural_Network_and_AI
{
    struct A
    {
        public virtual void Foo()
        {
            Console.WriteLine("A");
        }
    }

    struct B : A
    {
        public virtual override void foo()
        {
            Console.WriteLine("B");
        }
    }

    class Program
    {
        static void Main()
        {
            A v = new B();
            v.Foo();
        }
    }
}
