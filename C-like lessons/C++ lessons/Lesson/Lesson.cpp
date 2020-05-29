#include <GL/glut.h>
#include <stdlib.h>
#include <math.h>
#define a 320
#define b1 240
#define k 10.0
#define PI 3.14159
GLfloat l = 0.0, r = 0.0, b = 0.0, t = 0.0, W = 1920, H = 1080;


void reshape(GLsizei W, GLsizei H)
{
	glViewport(0, 0, W, H);
}

float F1(float x)
{
	return 1 / x;
}

float F2(float x)
{
	return x * x * x * x - 2 * x * x * x - x * x + x;
}

int ODZF1(float x)
{
	return (x != 0);
}

void ShowPoint(float x, float y, float colorR, float colorG, float colorB)
{
	float x0, y0;
	x0 = k * x;
	y0 = k * y;
	glColor3f(colorR, colorG, colorB);
	if (x0 >= l && x0 < r &&
		y0 >= b && y0 < t)
		glBegin(GL_POINTS);
	glVertex2f(x0, y0);
	glEnd();
}

void PlotF1()
{
	float x, h, xmin, xmax;
	h = 0.001;
	xmin = l;
	xmax = r;
	for (x = xmin; x <= xmax; x += h)
		if (ODZF1(x))
			ShowPoint(x, F1(x), 1, 0, 0);
}

void PlotF2()
{
	float x, h, xmin, xmax;
	h = 0.001;
	xmin = l;
	xmax = r;
	for (x = xmin; x <= xmax; x += h)
		if (ODZF1(x))
			ShowPoint(x, F2(x), 1, 0, 0);
}

void Axes(void)
{
	glColor3f(0.0f, 0.0f, 1.0f);
	glBegin(GL_LINES);
	glVertex2f(0, b);
	glVertex2f(0, t);
	glVertex2f(l, 0);
	glVertex2f(r, 0);
	float x0, y0;
	for (int i = 1; i <= r; i++)
	{
		x0 = k * i;
		glVertex2f(x0, -1);
		glVertex2f(x0, +1);
	}
	for (int i = 1; i <= r; i++)
	{
		y0 = k * i;
		glVertex2f(-1, y0);
		glVertex2f(+1, y0);
	}
	glEnd();
}

//-------------------------------------------
// Основная программа
//-------------------------------------------
void scene(void)
{
	glClear(GL_COLOR_BUFFER_BIT);
	Axes(); //построение и разметка осей координат
	PlotF1(); //построение первого графика
	PlotF2(); //построение второго графика
	glFlush();
}


void init(void)
{
	l = -a / k; r = (W - a) / k; b = -(H - b1) / k; t = b1 / k;
	glClearColor(1, 1, 0, 0);
	glClear(GL_COLOR_BUFFER_BIT);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(l, r, b, t);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
}

void main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(640, 480);
	glutInitWindowPosition(20, 20);
	glutCreateWindow("function graphs");
	glutReshapeFunc(reshape);
	glutDisplayFunc(scene);
	init();
	glutMainLoop();
}