#include <stdio.h>
#include <string.h>
#include <conio.h>
#define MaxLength 20

char Value(char Text[], int* Index)
/* Входные данные:                               		         */
/*      text - символьная строка,              		         */
/*      *i - индекс первой цифры числа в строке text.  */
/* Выходные данные:                           		         */
/*      *i - индекс следующего после числа символа.  */
/* Функция возвращает целое число            	          */
{
    char value = ' ';   /* возвращаемое значение  */
    while (Text[*Index] != '+' && Text[*Index] != '-' && Text[*Index] != '*' && Text[*Index] != '/' && Text[*Index] != ' ')
    {
        value = Text[*Index];
        (*Index)++;
    }
    return value;
}

void main()
{
    char  Text[MaxLength]; /* вх. текст - арифм. выражение */
    int   TextIndex;              /* индекс массива text */
    char  OperandStack[4];  /* стек операндов   */
    char   OperationStack[4];  /* стек операций    */
    int    PriorityStack[4];     /* стек приоритетов */
    int    StackPointer = -1;     /* указатель стека */
    char Result[MaxLength];
    int Begin = 0;
    int End = 0;
    bool IsFirst = true;
        
    printf("Enter the arithmetic expression.\n");
    gets_s(Text);

    while (Text[End] != ' ')
    {
        ++End;
    }

    TextIndex = -1;
    do
    {
        TextIndex++;
        /* запись числа, операции и ее приоритета в стек */
        StackPointer++;
        OperandStack[StackPointer] = Value(Text, &TextIndex);  OperationStack[StackPointer] = Text[TextIndex];
        switch (Text[TextIndex])
        {
        case '+':
        case '-': PriorityStack[StackPointer] = 1; break;
        case '*':
        case '/': PriorityStack[StackPointer] = 2; break;
        case ' ' /* пробел */: PriorityStack[StackPointer] = 0;                                                                  //a+b*c
        }                                                                                                                   //abc*+
        while (StackPointer > 0 && PriorityStack[StackPointer - 1] <= PriorityStack[StackPointer])                                         //ab*c+ 
        {                                                                        //ab+cd*+
            
        }

    } while (Text[TextIndex] != ' ');
    printf("Result: %s\n", Result);
    _getch();
}




