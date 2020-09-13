#include <iostream>
#include <ctime>
#include <vector>
#include "BinaryTree.cpp"
using namespace std;


int main()
{
	srand(time(0));
	binary_tree<int> tree;
	for (int i = 0; i < 10; ++i)
	{
		tree.push(rand() % 15 + 5);
	}
	auto printer = tree.printTree();
	//cout.width(2);
	for (vector<int>& string: printer)
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
