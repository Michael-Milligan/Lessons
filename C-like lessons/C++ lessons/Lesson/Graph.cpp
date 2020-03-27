#include <stdio.h>
#include <conio.h>

#define MAX_NUMBER_OF_NODES 10

int EnterGraph(int AdjacencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES])
{ 
	int NumberOfNodes;
	puts("Enter the number of nodes");
	scanf_s("%d", &NumberOfNodes);
	int i, j; /* номера вершин */
	/* Обнуление матрицы смежности */
	for (i = 0; i < NumberOfNodes; i++)
		for (j = 0; j < NumberOfNodes; j++)
		{
			AdjacencyMatrix[i][j] = 0;
		}
	puts("Enter the sequence of the lines");
	for (int i = 0; i < NumberOfNodes; ++i)
	{
		for (int j = 0; j < NumberOfNodes; ++j)
		{
			scanf_s("%d", &AdjacencyMatrix[i][j]);
		}
	}
	return NumberOfNodes;
}

int main()
{
	int AdjacencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES]; 
	int NumberOfNodes = EnterGraph(AdjacencyMatrix);
	
	int NumberOfNodesLinkedInBothDirections = 0;
	int NodesLinkedInBothDirections[MAX_NUMBER_OF_NODES];
	bool IsInVector = false;
	int h = 0;
	for (int i = 0; i < NumberOfNodes; ++i)
	{
		for (int j = 0; j < NumberOfNodes; ++j)
		{
			if (AdjacencyMatrix[i][j] == AdjacencyMatrix[j][i] && AdjacencyMatrix[i][j] != 0)
			{
				for (int k = 0; k < NumberOfNodes; ++k)
				{
					if (i == NodesLinkedInBothDirections[k]) IsInVector = true;
				}
				if (!IsInVector)
				{
					NodesLinkedInBothDirections[h] = i;
					++h;
				}
				IsInVector = false;
			}
		}
	}

	h = 0;

	while (NodesLinkedInBothDirections[h] > -10)
	{
		++NumberOfNodesLinkedInBothDirections;
		++h;
	}

	printf("The number of nodes linked in both directions: %d\n", NumberOfNodesLinkedInBothDirections);

	return 0;
}