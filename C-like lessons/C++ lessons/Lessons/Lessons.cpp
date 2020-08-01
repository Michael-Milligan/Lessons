#include <iostream>
#include <list>
#include <regex>
#include <string>
using namespace std;

int main()
{
	string a = "89991648759";
	tr1::regex query("8999(\d{3})(\d{2})(\d{2})");
	tr1::cmatch match;
	auto matches = regex_search(a.c_str(), match, query);
	return 0;
}
