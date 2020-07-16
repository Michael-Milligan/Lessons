#include <iostream>
#include <list>
using namespace std;

int get_result(int number, bool sign);

int main()
{
	cout << get_result(1, true);
	return 0;
}

/// <summary>
/// Returns exactly the same value of the parameter with the sign chosen
/// </summary>
/// <param name="number: ">The number which must be returned</param>
/// <param name="sign: ">The sign of the result: true for -, false for +</param>
/// <returns>The same number with the chosen sign</returns>
int get_result(int number, bool sign)
{
	return number * (int)sign * (-1);
}