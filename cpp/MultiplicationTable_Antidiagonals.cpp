#include <cmath>

//Multiplication table read by antidiagonals
//AKA https://oeis.org/A003991
unsigned long long
MultiplicationTable_Antidiagonals(unsigned long long n)
{
	unsigned long long t = floor((-1+sqrt(8*n-7))/2);
	return ((t*t+3*t+4)/2-n)*(n-(t*(t+1)/2));
}