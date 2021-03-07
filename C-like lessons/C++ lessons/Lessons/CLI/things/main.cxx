#include <iostream>
#include "appConfig.h"
#include "boolinq/boolinq.cxx"
#include "Funcs/funcs.h"
#include <string>

 int main(int argc, char *argv[])
 {
   
   std::list<int> int_list = boolinq::from(get_args(argc, argv)).
   skip(1).
   select([](std::string item){return std::stoi(item);}).toStdList();
   std::cout << boolinq::from(int_list).
      sum()
   << std::endl;

   double x = (double)6/9;
   std::cout << x << std::endl;
 }