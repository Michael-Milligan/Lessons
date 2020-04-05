#include <stdio.h>
#include <locale.h>
#include <conio.h>
#define Max_Number_of_Nodes 10 /* максимальное число вершин графа */
#define Max_number_of_Lines 30 /* максимальное число ребер */



void EnterMatrix(int Matrix[Max_Number_of_Nodes][Max_Number_of_Nodes], int n)
{
	int i, j, k; /* параметры циклов */
	printf("Enter the adjacency matrix:\n");
	//printf(" | ");
	for (j = 0; j < n; j++) //printf("%d ", j);
	//putchar('\n');
	//for (i = 0; i < 2 * n + 2; i++) putchar('-');

	for (i = 0; i < n; i++)
	{
		//printf("\n%d| ", i);
		for (j = 0; j < n; j++) scanf("%d", &Matrix[i][j]);

	}
	putchar('\n');
}



void main()
{
	int Adjacency_Matrix[Max_Number_of_Nodes][Max_Number_of_Nodes],
		Number_of_Nodes,
		Number_of_Lines;

	int i, j; /* индексы элементов матриц g1,g2 */

	printf("Enter the number of nodes:\n");
	scanf("%d", &Number_of_Nodes);
	EnterMatrix(Adjacency_Matrix, Number_of_Nodes);

	int Number_of_checked_node = 0;
	bool HasPredecessors = false;

	//int* Nodes = new int[Number_of_Nodes];
	int Nodes[4];
	int NodesIterator = 0;
	bool IsInArray = false;

	for (int i = 0; i < Number_of_Nodes; ++i)
	{
		HasPredecessors = false;
		Number_of_checked_node = -1;
		for (int j = 0; j < Number_of_Nodes; ++j)
		{
			if (Adjacency_Matrix[i][j] == 1) {
				Number_of_checked_node = i;
				break;
			}
		}
		if (Number_of_checked_node + 1)
		{
			for (int j = 0; j < Number_of_Nodes; ++j)
			{
				if (Adjacency_Matrix[j][Number_of_checked_node] == 1)
				{
					IsInArray = false;
					for (int f = 0; f < Number_of_Nodes; ++f)
					{
						if (Number_of_checked_node == Nodes[f]) IsInArray = true;
					}
					if (!IsInArray) Nodes[NodesIterator++] = Number_of_checked_node;
					break;
				}
			}
		}
	}

	printf("The nodes that have predecessors and successors: \n");
	for (int i = 0; i < NodesIterator; ++i)
	{
		printf("%d", Nodes[i]);
		if (i != (NodesIterator - 1)) printf(", ");
	}

	_getch();
}