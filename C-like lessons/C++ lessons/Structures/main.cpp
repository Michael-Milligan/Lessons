#include <iostream>
#include "mystring.cpp"

int main()
{
    mystring a("hello\0");
    mystring b(" world\0");
    std::cout << (a + b).toString() << std::endl;
    std::cout << (a*3).toString() << std::endl;
}