#include <iostream>
#include <windows.h>
#define NMAX 10 /* максимальное число вершин графа */
#define RMAX 100 /* максимальное число ребер */
using namespace std;

void SMEJNOST(int g1[NMAX][NMAX], int n)

{
	int i, j;
	cout << "Ќомера смежных вершин" << endl;
	for (i = 0; i < n; i++)
	{
		cout << "ƒл€ " << i << " " << "вершины смежны: ";
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
/* функци€ ввода матрицы смежности */
/*---------------------------------------------------------*/
void VVOD_MATR_SM(int g1[NMAX][NMAX], int n)
/* ¬ходные данные: n Ц количество вершин */
/* ¬ыходные данные: g1 Ц матрица смежности */
{
	int i, j; /* параметры циклов */
	/* ќбнуление матрицы смежности */
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++) g1[i][j] = 0;
	cout << "введите последовательность: ";
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
/* функци€ вывода матрицы инцидентности */
/*------------------------------------------------------------*/
void VIVOD_MATR_IN(int g2[NMAX][RMAX], int n, int k)
/* ¬ходные данные: g2 Ц матрица инцидентности ,
n Ц количество вершин ,
k Ц количество ребер */
{
	int i, j; /* параметры циклов */
	cout << "ћатрица инцидентности\n\n";
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
/* главна€ функци€ */
/*------------------------------*/

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int g1[NMAX][NMAX], g2[NMAX][RMAX] = { 0 }, n, k;
	int i, j;
	cout << "\n¬ведите количество вершин:";
	cin >> n;

	VVOD_MATR_SM(g1, n); /* ввод матрицы смежности g1 */

	/* ‘ормировавание матрицы инц-ти g2 */
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
	VIVOD_MATR_IN(g2, n, k); /* вывод м-цы g2 */
	cout << endl;
	system("pause");
}