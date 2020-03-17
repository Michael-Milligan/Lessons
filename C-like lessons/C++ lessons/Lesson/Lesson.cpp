#include <stdio.h>
#include <conio.h>
#include <clocale>

#define CRT_SECURE_NO_WARNINGS
#define FIO_LENGTH 20
#define OC_QUANTITY 6

struct STUDENT
{
	char FIO[FIO_LENGTH];
	char Oc[OC_QUANTITY];	
};

void main()
{
	setlocale(LC_ALL, "Russian");
	FILE* f;
	STUDENT tz;
	int i, s, j = 0;
	float Ocs[2];
	if ((f = fopen("st.txt", "r")) == NULL)
	{
		puts("Файл не найден");
		return;
	}
	puts("\nФамилия И.О.   Ср.балл");
	puts("------------------------");
	while (fgets((char*)&tz, sizeof(STUDENT), f) != NULL)
	{
		for (i = 0, s = 0; i < 4; ++i) 
		{ 
			s += tz.Oc[i] - '0'; 
		}
		tz.FIO[14] = '\0';
		printf("%s %.1f\n", tz.FIO, (float)s / 4);
		Ocs[j] = (float)s / 4; ++j;
	}

	fclose(f);
	_getch();
}
