#include <GL\glut.h> 
#include <math.h>
void draw();
void init();

/*√Ћј¬Ќјя ‘”Ќ ÷»я*/
void main(int argc, char** argv)
{
	glutInit(&argc, argv);; //инициализаци€ библиотеки GLUT. 
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB); //устанавливаетс€ режим диспле€:
	//использовать один буфер дл€ кадра; цвета представл€ть как смесь RGB.
	glutInitWindowSize(1920, 1080); //устанавливаетс€ размер экранного окна window. 
	glutInitWindowPosition(50, 50); //устанавливаетс€ положение (позици€) экранного окна
	//window.
	glutCreateWindow("Graphics"); //инициализируетс€ открытие экранного окна window.
	init();
	glutDisplayFunc(draw); //функци€ draw( ) регистрируетс€ как функци€ обратного вызова дл€ событи€ открыти€ или обновлени€ экранного окна.
	glutMainLoop(); //переводит программу в бесконечный цикл ожидани€ событи€.
}

/*‘”Ќ ÷»я »Ќ»÷»јЋ»«ј÷»»*/
void init()
{
	glClearColor(1.0, 1.0, 1.0, 0.0); //назначение цвета фона.
	glMatrixMode(GL_PROJECTION); //в качестве текущей устанавливаетс€ матрица проецировани€.
	glLoadIdentity(); //текуща€ матрица устанавливаетс€ в единицу.
	gluOrtho2D(1920, 1920, 1080, 1080); //устанавливаетс€ мировое окно.
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

			//рисуетс€ люба€ фигура
			glEnd();
		}
	glFlush();
}