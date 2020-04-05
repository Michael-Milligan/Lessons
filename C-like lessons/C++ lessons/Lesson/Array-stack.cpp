#include <stdio.h>
#include <string.h>
#include <conio.h>

#define MAX_CAPACITY_OF_STACK 100
#define MAX_NUMBER_OF_CHARS 100

char Stack[MAX_CAPACITY_OF_STACK];

int StackPointer = -1;

void push(char Data)
{
	Stack[++StackPointer] = Data;
}

char pop()
{
	return Stack[StackPointer--];
}

int Priority(char Sign)
{
	switch (Sign)
	{
	case '+': 
	case '-':
		return 1;
	case '*':
	case '/':
		return 2;
	default:
		return 0;
	}
}

int ReadChar(char Char)
{
	//If Char is a sign returns 0 if it's a letter returns 1
	switch (Char)
	{
	case '+':
	case '-':
	case '*':
	case '/':
		return 0;
	}

	if ((Char - 'a') >= 0 && ('z' - Char > 0)) return 1;
}

char ReadStack()
{
	return Stack[StackPointer];
}

int main()
{
	char Expression[MAX_NUMBER_OF_CHARS];
	int ExpressionIterator = 0;


	//Entering the expression
	puts("Enter the expression: ");
	gets_s(Expression);


	char Result[MAX_NUMBER_OF_CHARS];
	int ResultIterator = 0;

	// Deikstra's algorithm
	while (Expression[ExpressionIterator] != ' ')
	{
		if (ReadChar(Expression[ExpressionIterator])) Result[ResultIterator++] = Expression[ExpressionIterator++];
		else
		{
			while (Priority(ReadStack()) >= Priority(Expression[ExpressionIterator]))
			{
				Result[ResultIterator++] = pop();
			}
			push(Expression[ExpressionIterator++]);
		}
	}


	while (StackPointer != -1)
	{
		Result[ResultIterator++] = pop();
	}

	int i = 0;

	puts("\nResult: ");
	while (Result[i] > 0)
	{
		printf("%c", Result[i++]);
	}

	return 0;
}