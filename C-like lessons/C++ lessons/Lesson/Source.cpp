#include <stdio.h>
#include <string.h>
#include <conio.h>
#define MaxLength 20

char Value(char Text[], int* Index)
/* ������� ������:                               		         */
/*      text - ���������� ������,              		         */
/*      *i - ������ ������ ����� ����� � ������ text.  */
/* �������� ������:                           		         */
/*      *i - ������ ���������� ����� ����� �������.  */
/* ������� ���������� ����� �����            	          */
{
    char value = ' ';   /* ������������ ��������  */
    while (Text[*Index] != '+' && Text[*Index] != '-' && Text[*Index] != '*' && Text[*Index] != '/' && Text[*Index] != ' ')
    {
        value = Text[*Index];
        (*Index)++;
    }
    return value;
}

void main()
{
    char  Text[MaxLength]; /* ��. ����� - �����. ��������� */
    int   TextIndex;              /* ������ ������� text */
    char  OperandStack[4];  /* ���� ���������   */
    char   OperationStack[4];  /* ���� ��������    */
    int    PriorityStack[4];     /* ���� ����������� */
    int    StackPointer = -1;     /* ��������� ����� */
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
        /* ������ �����, �������� � �� ���������� � ���� */
        StackPointer++;
        OperandStack[StackPointer] = Value(Text, &TextIndex);  OperationStack[StackPointer] = Text[TextIndex];
        switch (Text[TextIndex])
        {
        case '+':
        case '-': PriorityStack[StackPointer] = 1; break;
        case '*':
        case '/': PriorityStack[StackPointer] = 2; break;
        case ' ' /* ������ */: PriorityStack[StackPointer] = 0;                                                                  //a+b*c
        }                                                                                                                   //abc*+
        while (StackPointer > 0 && PriorityStack[StackPointer - 1] <= PriorityStack[StackPointer])                                         //ab*c+ 
        {                                                                        //ab+cd*+
            
        }

    } while (Text[TextIndex] != ' ');
    printf("Result: %s\n", Result);
    _getch();
}




