#include <GL\glut.h> 
#include <math.h>
void draw();
void init();

/*������� �������*/
void main(int argc, char** argv)
{
	glutInit(&argc, argv);; //������������� ���������� GLUT. 
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB); //��������������� ����� �������:
	//������������ ���� ����� ��� �����; ����� ������������ ��� ����� RGB.
	glutInitWindowSize(1920, 1080); //��������������� ������ ��������� ���� window. 
	glutInitWindowPosition(50, 50); //��������������� ��������� (�������) ��������� ����
	//window.
	glutCreateWindow("Graphics"); //���������������� �������� ��������� ���� window.
	init();
	glutDisplayFunc(draw); //������� draw( ) �������������� ��� ������� ��������� ������ ��� ������� �������� ��� ���������� ��������� ����.
	glutMainLoop(); //��������� ��������� � ����������� ���� �������� �������.
}

/*������� �������������*/
void init()
{
	glClearColor(1.0, 1.0, 1.0, 0.0); //���������� ����� ����.
	glMatrixMode(GL_PROJECTION); //� �������� ������� ��������������� ������� �������������.
	glLoadIdentity(); //������� ������� ��������������� � �������.
	gluOrtho2D(1920, 1920, 1080, 1080); //��������������� ������� ����.
}

void draw()
{
	GLfloat l = -1.0, r = 2.0, b = -1.0, t = 1.0;
	GLint x = 0, y = 0, w = 60, h = 60;
	glClear(GL_COLOR_BUFFER_BIT);
	gluOrtho2D(l, r, b, t);
	for (x = 0; x <= 600; x += w)
		for (y = 0; y <= 480; y += h)
		{
			glPointSize(4);
			glViewport(x, y, w, h);
			glColor3f(0.0, 1.0, 0.0);
			glBegin(GL_POLYGON);
			float t, y, x;
			for (float t = 0; t < 100; t += 0.01)
			{
				x = sin(t);
				y = cos(t);
				glVertex2f(x, y);
			}

			//�������� ����� ������
			glEnd();
		}
	glFlush();
}