#include <stdio.h>
#include <string.h>
#include <conio.h>
#define MaxLength 20

char Value(char Text[], int* Index)
{
    char value = ' ';
    while (Text[*Index] != '+' && Text[*Index] != '-' && Text[*Index] != '*' && Text[*Index] != '/' && Text[*Index] != ' ')
    {
        value = Text[(*Index)++];
    }
    return value;
}

void main()
{
    char  Expression[MaxLength]; 
    int   ExpressionIndex;              
    char  OperandStack[10];  
    char   OperationStack[10];  
    int    PriorityStack[10];     
    int    StackPointer = -1;    
    char Result[MaxLength];
    int Begin = 0;
    int End = 0;
    bool IsFirst = true;
        
    printf("Enter the arithmetic expression.\n");
    gets_s(Expression);

    ExpressionIndex = -1;
    do
    {
        IsFirst = true;
        ExpressionIndex++;
        StackPointer++;
        OperandStack[StackPointer] = Value(Expression, &ExpressionIndex);  OperationStack[StackPointer] = Expression[ExpressionIndex];
        switch (Expression[ExpressionIndex])
        {
        case '+':
        case '-': PriorityStack[StackPointer] = 1; break;
        case '*':
        case '/': PriorityStack[StackPointer] = 2; break;
        case ' ' /* пробел */: PriorityStack[StackPointer] = 0;                                                                  
        }                                                                                                                   
        while (StackPointer > 0 && PriorityStack[StackPointer - 1] >= PriorityStack[StackPointer])
        {                                                                        
            if (IsFirst) {
                printf("%c%c%c", OperandStack[StackPointer], OperandStack[StackPointer - 1], OperationStack[StackPointer--]); 
                IsFirst = false; }
            else
                printf("%c%c", OperandStack[StackPointer], OperationStack[StackPointer--]);
        }
        IsFirst = true;
        while (StackPointer > 0 && PriorityStack[StackPointer - 1] <= PriorityStack[StackPointer])
        {
            if (IsFirst) {
                printf("%c%c%c", OperandStack[StackPointer], OperandStack[StackPointer - 1], OperationStack[StackPointer--]);
                StackPointer--;
                IsFirst = false;
            }
            else
                printf("%c%c", OperandStack[StackPointer], OperationStack[StackPointer--]);
        }

    } while (Expression[ExpressionIndex] != ' ');
    //printf("Result: %s\n", Result);
    _getch();
}




