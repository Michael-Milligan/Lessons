#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>
#include <locale.h>
#define MAX_LENGTH 9

struct Element 
{
	char Value[MAX_LENGTH];
	struct Element* pNext;
};

int main() {
	setlocale(LC_ALL, "rus");
	int Number_of_IDs;
	char Info[MAX_LENGTH];
	struct Element* Head, *Current;


	Head = NULL;
	printf("Введите количество вводимых идентификаторов\nn=");
	scanf_s("%d", &Number_of_IDs);

	printf("Заполните список:");
	for (int i = 0; i < Number_of_IDs; i++)
	{
		printf("\nВведите значение идентификатора: ");
		scanf_s("%s" ,&Info);


		Current = new Element;
		if (Current != NULL)
		{
			strcpy_s(Current->Value, Info);
		}
		else
		{
			printf("\nОшибка! Нет памяти для элемента списка");
			return 1;
		}


		if (i == 0)
		{
			Current->pNext = Head;
			Head = Current;
			Current = Current->pNext;
		}


		else
		{
			Current = Current->pNext;
		}
	}

	printf("\nСписок выглядит следующим образом:\n");
	for (Current = Head; Current != NULL; Current = Current->pNext)
	{
		puts(Current->Value);
		printf("\n");
	}
	_getch();
	return 0;

}