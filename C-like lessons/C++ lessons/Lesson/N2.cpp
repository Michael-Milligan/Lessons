#include <GL\glut.h>
#include <math.h>
void init();
void draw();
void main(int argc, char** argv)
{
	glutInit(&argc, argv);;
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutInitWindowSize(640, 480);
	glutInitWindowPosition(50, 50);
	glutCreateWindow("Graphics");
	init();
	glutDisplayFunc(draw);
	glutMainLoop();
}
void init()
{
	glClearColor(1.0, 1.0, 0.0, 0.0);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluOrtho2D(-10.0, 10.0, -2.0, 2.0);
}
void draw()
{
	const float w1 = 0.5;
	const float w2 = 0.3;
	int t, x1, x2, y;
	glClear(GL_COLOR_BUFFER_BIT);
	glViewport(10, 10, 600, 400);
	glColor3f(0.0, 1.0, 0.0);
	glBegin(GL_LINE_STRIP);
	for (int t = -6; t <= 6; t++)
	{
		x1 = w1 * t;
		x2 = w2 * t;
		y = (sin(x1) * cos(x2));
		glVertex2f(t, y);
	}
	glEnd();
	glFlush();
}