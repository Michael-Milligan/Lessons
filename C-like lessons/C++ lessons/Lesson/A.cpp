#include <stdio.h>
#include <conio.h>
#include <Windows.h>

#define	MAX_NUMBER_OF_NODES	10

int EnterGraph(int Lines_Matrix[100][2])
{
    int Number_of_Nodes = 0;
    int Max_Value = 1;
    int  Row;


    puts("Enter the quantity of lines");
    int Number_of_Lines;
    scanf_s("%d", &Number_of_Lines);

    //¬водим дуги
    puts("Enter the sequence of lines:");
    for (Row = 0; Row < Number_of_Lines; ++Row)
    {
        scanf_s("%d", &Lines_Matrix[Row][0]);
        scanf_s("%d", &Lines_Matrix[Row][1]);
    }

    //»щем максимальный номер вершины
    for (int i = 0; i < 100; ++i)
    {
        for (int j = 0; j < 2; ++j)
        {
            if (Max_Value < Lines_Matrix[i][j]) Max_Value = Lines_Matrix[i][j];
        }
    }
    Number_of_Nodes = Max_Value + 1;
    return  Number_of_Nodes;
}

/*  √лавна€ функци€  */
int main()
{
    int Given_Number_of_Nodes;
    puts("Enter the number of nodes");
    scanf_s("%d", &Given_Number_of_Nodes);
    int Lines_Matrix[100][2];
    int  Number_of_Nodes = 0;
    Number_of_Nodes = EnterGraph(Lines_Matrix);
    int Adjacency_Matrix[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES];
    int Row = 0;

    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        for (int j = 0; j < Number_of_Nodes; ++j)
        {
            Adjacency_Matrix[i][j] = 0;
        }
    }

    while (Lines_Matrix[Row][0] > -1 && Row < 100)
    {
        Adjacency_Matrix[Lines_Matrix[Row][0]][Lines_Matrix[Row][1]] = 1;
        ++Row;
    }

    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        for (int j = 0; j < Number_of_Nodes; j++)
        {
            if (Adjacency_Matrix[i][j] == 0) Adjacency_Matrix[i][j] = Adjacency_Matrix[j][i];
        }
    }

    puts("\nAdjacency Matrix:");
    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        for (int j = 0; j < Number_of_Nodes; ++j)
        {
            printf("%d ", Adjacency_Matrix[i][j]);
        }
        puts("\n");
    }

    int Difference = Given_Number_of_Nodes - Number_of_Nodes;
    if (Difference) puts("There is at least one unconnected node");
    else puts("There isn\'t any unconnected node");

    system("pause");
    return 0;
}
