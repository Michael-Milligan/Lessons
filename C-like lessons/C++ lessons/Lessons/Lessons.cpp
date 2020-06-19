#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

struct Element
{
	int Data;
	Element* pNext;
};

void pop_back(Element** Head)
{
	Element* Current = *Head;
	if (Current == NULL) return;
	while (Current->pNext->pNext != nullptr)
	{
		Current->pNext = Current->pNext->pNext;
	}
	delete Current->pNext;
	Current->pNext = NULL;

}

int main()
{
	Element* Head = new Element;
	Head->Data = 15;
	Head->pNext = new Element;
	Head->pNext->Data = 20;
	Head->pNext->pNext = NULL;
	//Заполнение списка
	pop_back(&Head); //Вызов функции
	return 0;
}


