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
	tree.push(5);
	tree.push(10);
	tree.push(4);
	tree.push(7);
	tree.push(11);
	tree.push(3);
	tree.push(6);
	tree.push(8);
	tree.push(9);
	auto printer = tree.printTree();
	
	for (vector<int>& string: printer)
	{
		for (auto& cell : string)
		{
			if (cell > 0)
				cout << cell << " ";
			else
				cout << " ";
		}
		cout << endl;
	}

	cout << endl << endl;

	tree.erase(7);
	printer = tree.printTree();
	for (vector<int>& string : printer)
	{
		for (auto& cell : string)
		{
			if (cell > 0)
				cout << cell << " ";
			else
				cout << " ";
		}
		cout << endl;
	}

	return 0;
}


