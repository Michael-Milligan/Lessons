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

bool IsInArray(int Number, int Row, int Array[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES])
{
    for (int i = 0; i < MAX_NUMBER_OF_NODES; ++i)
    {
        if (Array[Row][i] == Number) return true;
    }
    return false;
}

/*  √лавна€ функци€  */
int main()
{
    int Lines_Matrix[100][2];
    int  Number_of_Nodes = 0;
    Number_of_Nodes = EnterGraph(Lines_Matrix);
    int Row = 0;
    int Predessesors[MAX_NUMBER_OF_NODES][MAX_NUMBER_OF_NODES];

    while (Row<100 && Lines_Matrix[Row][0] > -1)
    {
        int h = 0;
        while (Predessesors[Lines_Matrix[Row][1]][h] > -1) { ++h; }
        Predessesors[Lines_Matrix[Row][1]][h] = Lines_Matrix[Row][0];
        ++Row;
    }

    int i = 0, j = 0;
    while (Predessesors[i][0] > -1)
    {
        j = 0;
        printf("The node #%d has predessessors: ", i);
        while (Predessesors[i][j] > -1)
        {

            printf("%d ", Predessesors[i][j]);
            ++j;
        }
        puts("\n");
        ++i;
    }

    system("pause");
    delete Predessesors;
    return 0;
}
