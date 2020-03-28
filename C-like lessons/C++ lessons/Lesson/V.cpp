#include <stdio.h>
#include <conio.h>

#define	MAX_NUMBER_OF_NODES	10
#define MAX_NUMBER_OF_LINES 100

int EnterGraph(int AdjacencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES])
/* Возвращаемое значение – число вершин графа */
{
    int Number_of_Nodes;
    int  i, j;	/* номера вершин */
    puts("Enter the number of nodes");
    scanf("%d", &Number_of_Nodes);
    /* Обнуление матрицы смежности */
    for (i = 0; i < Number_of_Nodes; i++)
        for (j = 0; j < Number_of_Nodes; j++)   AdjacencyMatrix[i][j] = 0;
    puts("Enter the sequence of lines:");
    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        for (int j = 0; j < Number_of_Nodes; ++j)
        {
            scanf_s("%d", &AdjacencyMatrix[i][j]);
        }
    }
    return  Number_of_Nodes;
}


int main()
{
    int AdjacencyMatrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES];
    int  Number_of_Nodes;
    Number_of_Nodes = EnterGraph(AdjacencyMatrix);
    int Lines_Matrix[100][2];
    int h = 0;

    //Проверяем матрицу на 1
    for (int i = 0; i < MAX_NUMBER_OF_NODES; ++i)
    {
        for (int j = 0; j < MAX_NUMBER_OF_NODES; ++j)
        {
            if (AdjacencyMatrix[i][j] == 1)
            {
                Lines_Matrix[h][0] = i;
                Lines_Matrix[h][1] = j;
                ++h;
            }
        }
    }

    puts("\nLines:");
    h = 0;
    while (Lines_Matrix[h][0] > -1 && h < MAX_NUMBER_OF_LINES)
    {
        printf(" %d->%d  ", Lines_Matrix[h][0], Lines_Matrix[h][1]);
        ++h;
    }
    return 0;
}
