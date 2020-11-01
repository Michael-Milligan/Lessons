//#include <iostream>
//#include <ctime>
//#include <cmath>
//#include <vector>
//#include "BinaryTree.cpp"
//
//using namespace std;
//
///// <summary>
///// Return true if points are on the same line
///// </summary>
//bool check(int k1, int m1, int k2, int m2)
//{
//	
//}
//
//int find_k(int x1, int y1, int x2, int y2)
//{
//
//}
//
//
//
//int main()
//{
//	/*srand(time(0));
//	binary_tree<int> tree;
//	tree.push(5);
//	tree.push(10);
//	tree.push(4);
//	tree.push(7);
//	tree.push(11);
//	tree.push(3);
//	tree.push(6);
//	tree.push(8);
//	tree.push(9);
//	auto printer = tree.printTree();
//	
//	for (vector<int>& string: printer)
//	{
//		for (auto& cell : string)
//		{
//			if (cell > 0)
//				cout << cell << " ";
//			else
//				cout << " ";
//		}
//		cout << endl;
//	}
//
//	cout << endl << endl;
//
//	tree.erase(7);
//	printer = tree.printTree();
//	for (vector<int>& string : printer)
//	{
//		for (auto& cell : string)
//		{
//			if (cell > 0)
//				cout << cell << " ";
//			else
//				cout << " ";
//		}
//		cout << endl;
//	}*/
//
//	int number;
//	cin >> number;
//	int x1, x2, y1, y2;
//	cin >> x1 >> y1 >> x2 >> y2;
//	int k = find_k(), m = 0;
//	bool IsNo = false;
//
//	for (int i = 0; i < ; i++)
//	{
//		int x3, y3;
//		cin >> x3 >> y3;
//		if (!check(k, m, x2, y2))
//		{
//			cout << "No";
//			IsNo = true;
//			break;
//		}
//	}
//	
//	
//
//
//	return 0;
//}
#include <iostream>

bool IsPrime(int n)
{
	for (int i = 2; i * i < n; i++)
	{
		if (n % i == 0) return false;
	}
	return true;
}

int main()
{
	for (int n = 2; n <= 5; n++)
	{
		if (IsPrime(n))
			std::cout << n << " is 'n\n";
	}
	return 0;
}
