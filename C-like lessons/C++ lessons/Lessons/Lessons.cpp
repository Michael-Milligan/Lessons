#include <iostream>
#include <ctime>
#include <vector>
#include "BinaryTree.cpp"
using namespace std;

int Factorial()
{
	int number, result = 1;
	cin >> number;
	if (number < 0)
	{
		cout << "Error! You must enter natural number only";
		return -1;
	}
	for (int i = 1; i <= number; i = i + 1)
	{
		result = result * i;
	}
	cout << result;
	return 0;
}

int main()
{
	srand(time(0));
	binary_tree<int> tree;
	for (int i = 0; i < 10; ++i)
	{
		tree.push(i);
	}
	auto printer = tree.printTree();
	
	for (vector<int>& string: printer)
	{
		for (auto& cell : string)
		{
			if (cell >= 0)
				cout << cell << " ";
			else
				cout << " ";
		}
		cout << endl;
	}

	cout << endl << endl;

	//tree.erase(5);
	printer = tree.printTree();
	for (vector<int>& string : printer)
	{
		for (auto& cell : string)
		{
			if (cell != 0)
				cout << cell << " ";
			else
				cout << " ";
		}
		cout << endl;
	}

	return 0;
}


