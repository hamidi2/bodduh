// t2-2.cpp : Defines the entry point for the console application.
//

#include <stdio.h>
#include <conio.h>

extern "C" void sortDB();

void main()
{
	sortDB();
	fprintf(stderr, "done.");
	if (!_getch())
		_getch();
}

