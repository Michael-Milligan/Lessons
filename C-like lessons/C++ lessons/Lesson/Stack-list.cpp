#include <stdio.h>
#include <string.h>
#include <conio.h>
#define MAX_NUMBER_OF_SYMBOLS 20

struct Element
{
	char Data;
	Element* pNext;
};

void push(char Data, Element** Head)
{
	Element NewHead = Element{ Data, *Head };
	*Head = &NewHead;
}

char pop(Element** Head)
{
	char temp = (*Head)->Data;
	*Head = (*Head)->pNext;
	return temp;
}

char read(Element* Head)
{
	if (Head != nullptr) return Head->Data;
	return '0';
}

//int ReadChar(char Char , Element* OperandStack, Element* OperationStack, Element* PriorityStack)
//{
//	switch (Char)
//	{
//	case '+': push(Char, OperationStack);
//		push(1, PriorityStack);
//		return 1;
//	case '-': push(Char, OperationStack);
//		push(1, PriorityStack);
//		return 1;
//	case '*': push(Char, OperationStack);
//		push(2, PriorityStack);
//		return 1;
//	case '/': push(Char, OperationStack);
//		push(2, PriorityStack);
//		return 1;
//	case ' ': push(Char, OperationStack);
//		push(0, PriorityStack);
//		return 1;
//	default: push(Char, OperandStack);
//		break;
//	}
//}

int ReadChar(char Char)
{
	//Returns 1 if char is a sign and 0 if it's a letter
	switch (Char)
	{
	case '+': 
		return 1;
	case '-': 
		return 1;
	case '*': 
		return 1;
	case '/':
		return 1;
	default: return 0;
	}
}

bool compare_priority(char FirstSign, char SeconSign)
{
	//Checks whether the first sign has higher or equal priority than the second one
	int FirstSignPriority, SecondSignPriority;
	switch (FirstSign)
	{
	case '+':
	case '-':
		FirstSignPriority = 1;
		break;
	case '*':
	case '/':
		FirstSignPriority = 2;
		break;
	default:
		FirstSignPriority = 0;
	}

	switch (SeconSign)
	{
	case '+':
	case '-':
		SecondSignPriority = 1;
		break;
	case '*':
	case '/':
		SecondSignPriority = 2;
		break;	
	default:
		SecondSignPriority = 0;
	}
	return FirstSignPriority >= SecondSignPriority;
}

int main()
{
	Element* OperandStack;
	Element* OperationStack;
	Element* PriorityStack;
	Element* CommonStack = {};

	puts("Enter the expression");
	char Expression[MAX_NUMBER_OF_SYMBOLS];
	gets_s(Expression);

	int ExpressionIterator = 0;
	char Result[MAX_NUMBER_OF_SYMBOLS];
	int ResultIterator = 0;

	while (Expression[ExpressionIterator] != ' ')
	{

		if (!ReadChar(Expression[ExpressionIterator])) 
			Result[ResultIterator++] = Expression[ExpressionIterator];
		else
		{
			while (compare_priority(read(CommonStack), Expression[ExpressionIterator]))
			{
				Result[ResultIterator++] = pop(&CommonStack);
			}
			push(Expression[ExpressionIterator], &CommonStack);
		}
		ExpressionIterator++;
	}

	while (CommonStack != nullptr)
	{
		Result[ResultIterator++] = pop(&CommonStack);
	}

	puts("Result:\n");
	puts(Result);

	return 0;
}