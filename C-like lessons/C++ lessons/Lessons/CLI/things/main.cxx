#include <iostream>
#include "appConfig.h"
#include "boolinq/boolinq.cxx"
#include "Funcs/funcs.h"
#include <string>

 int main(int argc, char *argv[])
 {
   std::list<std::string> args;

   for (int i = 0; i < argc; ++i)
   {
      args.push_back(std::string(argv[i]));
   }
   

   std::list<int> int_list = boolinq::from(args).
   skip(1).
   select([](std::string item){return std::stoi(item);}).toStdList();
   std::cout << boolinq::from(int_list).
      sum()
   << std::endl;
 }