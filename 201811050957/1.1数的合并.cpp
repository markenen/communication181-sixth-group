#include<iostream>
using namespace std;
int  fun0(int a, int b)
{

	int c;
	c = a % 10 * 1000 + b % 10 * 100 + a / 10 * 10 + b / 10;
	return c;

}
int  fun1(int& a, int& b, int& c)
{

	c = a % 10 * 1000 + b % 10 * 100 + a / 10 * 10 + b / 10;
	return 0;

}
int  fun2(int* a, int* b, int* c)
{

	*c = *a % 10 * 1000 + *b % 10 * 100 + *a / 10 * 10 + *b / 10;
	return 0;

}
int main()
{

	int a, b, c1, c2, c3;
	cout << "输入A和B两个正整数: " << endl;
	cin >> a >> b;
	c1 = fun0(a, b);
	cout << "得到整数: " << c1 << endl;
	fun1(a, b, c2);
	cout << "得到整数: " << c2 << endl;
	fun2(&a, &b, &c3);
	cout << "得到整数: " << c3 << endl;

}
