#include <iostream>
#include <windows.h>
#define NMAX 10 /* ������������ ����� ������ ����� */
#define RMAX 100 /* ������������ ����� ����� */
using namespace std;

void SMEJNOST(int g1[NMAX][NMAX], int n)

{
	int i, j;
	cout << "������ ������� ������" << endl;
	for (i = 0; i < n; i++)
	{
		cout << "��� " << i << " " << "������� ������: ";
		for (j = 0; j < n; j++)
		{
			if (g1[i][j] == 1)
			{
				cout << j << " ";
			}
		}
		cout << endl;
	}


}

/*---------------------------------------------------------*/
/* ������� ����� ������� ��������� */
/*---------------------------------------------------------*/
void VVOD_MATR_SM(int g1[NMAX][NMAX], int n)
/* ������� ������: n � ���������� ������ */
/* �������� ������: g1 � ������� ��������� */
{
	int i, j; /* ��������� ������ */
	/* ��������� ������� ��������� */
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++) g1[i][j] = 0;
	cout << "������� ������������������: ";
	while (cin >> i >> j)
	{
		if (i == -1 || j == -1)
			break;
		else
			g1[i][j] = g1[j][i] = 1;
	}
	cout << " ";
	for (j = 0; j < n; j++)
		cout << j;
	cout << endl;
	cout << " ";
	for (j = 0; j < n; j++)
		cout << "-";

	for (i = 0; i < n; i++)
	{
		cout << endl << i << "|";
		for (j = 0; j < n; j++) cout << g1[i][j];
	}
}
/*------------------------------------------------------------*/
/* ������� ������ ������� ������������� */
/*------------------------------------------------------------*/
void VIVOD_MATR_IN(int g2[NMAX][RMAX], int n, int k)
/* ������� ������: g2 � ������� ������������� ,
n � ���������� ������ ,
k � ���������� ����� */
{
	int i, j; /* ��������� ������ */
	cout << "������� �������������\n\n";
	cout << " ";
	for (j = 0; j < k; j++)
		cout << j;
	cout << endl;
	cout << " ";
	for (j = 0; j < k; j++)
		cout << "-";

	for (i = 0; i < n; i++)
	{
		cout << endl << i << "|";
		for (j = 0; j < k; j++) cout << g2[i][j];
	}
}
/*------------------------------*/
/* ������� ������� */
/*------------------------------*/

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int g1[NMAX][NMAX], g2[NMAX][RMAX] = { 0 }, n, k;
	int i, j;
	cout << "\n������� ���������� ������:";
	cin >> n;

	VVOD_MATR_SM(g1, n); /* ���� ������� ��������� g1 */

	/* �������������� ������� ���-�� g2 */
	SMEJNOST(g1, n);

	k = 0;
	for (i = 0; i < n; i++)
		for (j = i; j < n; j++)
			if (g1[i][j])
			{
				if (i == j && g1[i][j] == 1)
				{

					g2[i][k] = 2;
					k++;
				}
				else
				{
					g2[i][k] = 1;
					g2[j][k] = 1;
					k++;
				}
			}
	VIVOD_MATR_IN(g2, n, k); /* ����� �-�� g2 */
	cout << endl;
	system("pause");
}