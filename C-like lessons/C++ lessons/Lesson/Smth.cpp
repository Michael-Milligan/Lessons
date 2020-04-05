#include<stdio.h>
#include<stdlib.h>

/* �������� ��p����p�(�������� �����) */
struct st
{
    char c; struct st* next;
};
struct st* push(struct st*, char);
/* �p������� ������� */
char DEL(struct st**);
int PRIOR(char);

void main(void)
{
    /* ���� ���p���� ���� */
    struct st* OPERS = NULL;
    char a[80], outstring[80];
    int k, point;
    do
    {
        puts("������� ��p������(� ����� '='):");
        fflush(stdin);
        /* ���� �p������������� ��p������ */
        gets_s(a);
        k = point = 0;
        /* �����p��� , ���� �� ������ �� '=' */
        while (a[k] != '\0' && a[k] != '=')
        {
            /* ���� ���p����� ������ - ')' */
            if (a[k] == ')')
                /* �� ����������� �� ����� � �������� ��p��� */
            {
                /* ��� ����� ���p���� �� ��������� */
                while ((OPERS->c) != '(')
                    /* ���p������� ������ */
                    outstring[point++] = DEL(&OPERS);
                /* ������� �� ����� ���� ���p������� ������ */
                DEL(&OPERS);
            }
            /* ���� ���p����� ������ - ����� , �� */
            if (a[k] >= 'a' && a[k] <= 'z')
                /* ��p��������� � � �������� ��p��� */
                outstring[point++] = a[k];
            /* ���� ���p����� ������ - '(' , �� */
            if (a[k] == '(')
                /* ����������� � � ���� */
                OPERS = push(OPERS, '(');
            if (a[k] == '+' || a[k] == '-' || a[k] == '/' || a[k] == '*')
                /* ���� ��������� ������ - ���� ���p���� , ��: */
            {
                /* ���� ���� ���� */
                if (OPERS == NULL)
                    /* ���������� � ���� ���p���� */
                    OPERS = push(OPERS, a[k]);
                /* ���� �� ���� */
                else
                    /* ���� �p��p���� ����������� ���p���� ������
                                   �p��p����� ���p���� �� ��p���� ����� */
                    if (PRIOR(OPERS->c) < PRIOR(a[k]))
                        /* ����������� ����������� ���p���� �� ���� */
                        OPERS = push(OPERS, a[k]);
                /* ���� �p��p���� ������ */
                    else
                    {
                        while ((OPERS != NULL) && (PRIOR(OPERS->c) >= PRIOR(a[k])))
                            /* ��p��������� � �������� ��p��� ��� ���p����
                                               � ������� ��� p����� �p��p������ */
                            outstring[point++] = DEL(&OPERS);
                        /* ���������� � ���� �����������  ���p���� */
                        OPERS = push(OPERS, a[k]);
                    }
            }
            /* ��p���� � ���������� ������� ������� ��p��� */
            k++;
        }
        /* ����� p������p���� ����� ��p������ */
        while (OPERS != NULL)
            /* ��p��������� ��� ���p���� �� */
            outstring[point++] = DEL(&OPERS);
        /* ����� � �������� ��p��� */
        outstring[point] = '\0';
        /* � �������� � */
        printf("\n%s\n", outstring);
        fflush(stdin);
        puts("\n�����p���(y/n)?");
    } while (getchar() != 'n');
}

/* ������� push ���������� �� ���� (�� ��p���� ����p��� ��������� HEAD)
   ������ a . ����p����� ��������� �� ����� ��p���� ����� */
struct st* push(struct st* HEAD, char a)
{
    struct st* PTR;
    /* ��������� ������ */
    if ((PTR = (st*)malloc(sizeof(struct st))) == NULL)
    {
        /* ���� � ��� - ����� */
        puts("�� ������"); exit(-1);
    }
    /* ������������� ��������� ��p���� */
    PTR->c = a;
    /* � ����������� � � ����� */
    PTR->next = HEAD;
    /* PTR -����� ��p���� ����� */
    return PTR;
}

/* ������� DEL ������� ������ � ��p���� �����.
   ����p����� ��������� ������.
   �������� ��������� �� ��p���� ����� */
char DEL(struct st** HEAD)
{
    struct st* PTR;
    char a;
    /* ���� ���� ����,  ����p������� '\0' */
    if (*HEAD == NULL) return '\0';
    /* � PTR - ��p�� ��p���� ����� */
    PTR = *HEAD;
    a = PTR->c;
    /* �������� ��p�� ��p���� ����� */
    *HEAD = PTR->next;
    /* ������������ ������ */
    free(PTR);
    /* ����p�� ������� � ��p���� ����� */
    return a;
}

/* ������� PRIOR ����p����� �p��p���� �p���. ���p���� */
int PRIOR(char a)
{
    switch (a)
    {
    case '*':
    case '/':
        return 3;

    case '-':
    case '+':
        return 2;

    case '(':
        return 1;
    }
}