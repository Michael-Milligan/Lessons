#include <iostream>
#include <ctime>
#include <cmath>
#include <vector>
#include "BinaryTree.cpp"
using namespace std;

double factorial(int n)
{
	double fn = 1;
	for (double i = 1; i <= n; i++)
		fn *= i;
	return fn;
}

double taylor_cos(double number, double accuracy)
{
	double a = 0, cos = 0;
	int i = 0;
	do
	{
		cos += a;
		a = pow(-1, i) * pow(number, 2 * i) / (factorial(2 * i));
		i += 1;
	} while (abs(a) >= accuracy);
	return cos;
}


int main()
{
	/*srand(time(0));
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
	}*/

	double x, cos = 0, eps;
	cin >> x >> eps;
	int i = 0;
	cos = taylor_cos(x, eps);
	cout << cos;
	return 0;
}


