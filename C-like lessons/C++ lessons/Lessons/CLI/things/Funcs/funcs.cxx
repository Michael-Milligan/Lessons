#include "funcs.h"
#ifndef DEBUG
    #define DEBUG
    #include <string>
    #include <list>
#endif // DEBUG

int factorial(int number) 
{
    int result = 1;
    for (int i = 2; i <= number; ++i)
    {
        result *= i;
    }
    return result;
}

std::list<std::string> get_args(int argc, char *argv[])
{
   std::list<std::string> args;

   for (int i = 0; i < argc; ++i)
   {
      args.push_back(std::string(argv[i]));
   }
}
