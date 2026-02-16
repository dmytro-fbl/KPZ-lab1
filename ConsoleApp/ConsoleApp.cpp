// ConsoleApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <Windows.h>
#include <math.h>
#include <stdio.h>


int main()
{

	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	printf("hello\n");

	float a = 100, b = 0.001, x1, x2, x3, x;

	x1 = pow(a - b, 4);
	x2 = (pow(a, 4) - 4 * pow(a, 3) * b + 6 * a * a * b * b);
	x3 = pow(b, 4) - 4 * a * pow(b, 3);
	x = (x1 - x2) / x3;

	printf("при значенні float\n");
	printf("x1 =%f\n", x1);
	printf("x2 =%f\n", x2);
	printf("x3 =%f\n", x3);
	printf("x =%f\n", x);
	return 0;


}


// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
