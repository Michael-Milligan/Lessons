#include <iostream>
using namespace std;

int dictionary[50][2];

void increment_dictionary_value(char symbol)
{
	for (int i = 0; i < 50; ++i)
	{
		if (dictionary[0][i] == (int)symbol)
		{
			dictionary[1][i] = dictionary[1][i] + 1;
			return;
		}
	}
}

int main()
{
	string input;
	cin >> input;
	for (int i = 0; i < length; i++)
	{

	}
}

//dict[]
//[](dict)
//1 //0

//int a[5]{1,2,3,4,5}
//a[2] = a[2] + 1