#include <stdio.h>
#include <string>
using namespace std;

struct Student
{
	string Names;
	string Marks;
};

int main()
{
	FILE* File = fopen("1.txt", "r");
	string temp = "";
	int NumberOfStudents = 0;

	while (!feof(File))
	{

	}
}