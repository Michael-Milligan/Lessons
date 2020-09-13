#include <iostream>
#include <ctime>
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

	return 0;
}
