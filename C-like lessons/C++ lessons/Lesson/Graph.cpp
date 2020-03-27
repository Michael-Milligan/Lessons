#include <stdio.h>
#include <conio.h>

#define MAX_NUMBER_OF_NODES 10 
#define MAX_NUMBER_OF_LINES 10

void EnterGraph(int IncidencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_LINES], int& NumberOfNodes, int& NumberOfLines)
{ 
	puts("Enter the number of nodes and number of lines\n");
	scanf_s("%d %d", &NumberOfNodes, &NumberOfLines);
	int i, j; /* номера вершин */
	/* Обнуление матрицы смежности */
	for (i = 0; i < NumberOfNodes; i++)
		for (j = 0; j < NumberOfNodes; j++) IncidencyMatrix[i][j] = 0;
	puts("Enter the sequence of the incidencies\n");
	for (int i = 0; i < NumberOfNodes; ++i)
	{
		for (int j = 0; j < NumberOfLines; ++j)
		{

		}
	}
}


int main()
{
	int IncidencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_LINES]; 
	int NumberOfNodes, NumberOfLines; 
	EnterGraph(IncidencyMatrix, NumberOfNodes, NumberOfLines);
	return 0;
}