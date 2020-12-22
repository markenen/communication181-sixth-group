#define question 5
#if question==1
void fun(int& a, int& b, int& c);		//引用传参
int fun(int& a, int& b);				//返回值传参
void fun(int& a, int& b, int* c);		//指针传参
#elif question==2
void monkey_arr(int& m, int& n);
void monkey_linear(int& m, int& n);
#elif question==3
void schoolship(const char* file);
#elif question==4
void virus(const char* file);
#elif question==5
void stack(void);
#elif question==6

#endif