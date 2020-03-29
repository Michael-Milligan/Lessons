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
    int Lines_Matrix[100][2];
    int  Number_of_Nodes = 0;
    Number_of_Nodes = EnterGraph(Lines_Matrix);
    int Row = 0;
    int* Nodes = new int[Number_of_Nodes];
    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        Nodes[i] = 0;
    }

    for (Row = 0; Row < 100 && Lines_Matrix[Row][0] > -1; ++Row)
    {
        Nodes[Lines_Matrix[Row][0]]++;
    }

    for (int i = 0; i < Number_of_Nodes; ++i)
    {
        if (Nodes[i] > 2) printf("The node #%d has %d successors\n", i, Nodes[i]);
    }

    system("pause");
    delete Nodes;
    return 0;
}
