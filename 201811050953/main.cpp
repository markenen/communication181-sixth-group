#include<iostream>
#include"Header.h"
int main(void)
{
#if question==1
	int a, b, c;
	std::cout << "please input two number" << std::endl;
	std::cin >> a >> b;
	fun(a, b, c);
	std::cout << c << std::endl;
	c = 0;
	std::cout << fun(a, b) << std::endl;;
	c = 0;
	fun(a, b, &c);
	std::cout << c << std::endl;
#elif question==2
	int m, n;
	std::cout << "please input two number" << std::endl;
	std::cin >> m >> n;
	monkey_arr(m, n);
	monkey_linear(m, n);
#elif question==3
	const char* file = "C:/Users/sjzmd/Documents/学校/程序设计训练/Union/ranking.txt";
	schoolship(file);
#elif question==4
	const char* file = "C:/Users/sjzmd/Documents/学校/程序设计训练/Union/map.txt";
	virus(file);
#elif question==5
	stack();
#elif question==6
	class_test();
#endif 
}