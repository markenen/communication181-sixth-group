#include <iostream>
#include "Header.h"
#if question==1
//1.function wizard
void fun(int &a, int &b,int &c)		//引用传参
{
	int m, n, x, y;
	m = (a % 100) / 10; n = a % 10;
	x = (b % 100) / 10; y = b % 10;
	c = m * 10 + n * 1000 + x + y * 100;
}
int fun(int& a, int& b)		//返回值传参
{
	int m, n, x, y;
	m = (a % 100) / 10; n = a % 10;
	x = (b % 100) / 10; y = b % 10;
	return(m * 10 + n * 1000 + x + y * 100);
}
void fun(int& a, int& b, int* c)		//指针传参
{
	int m, n, x, y;
	m = (a % 100) / 10; n = a % 10;
	x = (b % 100) / 10; y = b % 10;
	*c = m * 10 + n * 1000 + x + y * 100;
}
#elif question==2
#include <vector>
//2.liear table problem
void monkey_arr(int& m, int& n)
{
	if (m < n)
	{
		std::cout << "input error" << std::endl;
		return;
	}
	if (n == 1)
	{
		std::cout << m << std::endl;
		return;
	}
	std::vector<int> arr(m);
	/*
	使用vector实现不定长数组
	其他方法：用指针指向new动态分配的长度为len*sizeof(int)的内存空间
	int *p=new int[len];
	delete [] p;
	*/
	int len = m, del_flag = 0;
	for (int i = 1; i <= m; i++)
		arr[i-1] = i;
	for (int i = 0; i < m; i++)
	{
		if (arr[i]!=0)
		{
			del_flag++;
			if (del_flag==n)
			{
				arr[i] = 0;
				del_flag = 0;
				len--;
				if (len==1)
				{
					break;
				}
			}
		}
		if (i == m - 1)
			i = -1;
	}
	for (int i = 0; i < m; i++)
	{
		if (arr[i]!=0)
		{
			std::cout << arr[i] << std::endl;
		}
	}
}

typedef struct Table {
	int number;
	Table* next;
};
void monkey_linear(int& m, int& n)
{
	if (m < n)
	{
		std::cout << "input error" << std::endl;
		return;
	}
	if (n==1)
	{
		std::cout << m << std::endl;
		return;
	}
	Table F;
	Table *p=&F,*q=&F;
	F.number = 1;

	for (int i = 1; i < m; i++)
	{
		p->next = new Table;
		p = p->next; p->number = i+1;
	}
	p->next = &F;
	while (true)
	{
		for (int i = 0; i < n-1; i++)
		{
			p = p->next;
		}
		q = p->next;
		p->next = q->next;

		if (p->next==p)
		{
			std::cout << p->number<<std::endl;
			break;
		}
	}
}
#elif question==3
//schoolship question
#include <fstream>
#include <vector>
#include <sstream>
#include <algorithm>
typedef struct student
{
	int number;
	int cheinese_score;
	int math_score;
	int english_score;
	int total_score;
}Student;
void swap(student& a, student& b)
{
	student c = a;
	a = b;
	b = c;
}
void quick_sort_recursive(student list[], int start, int end)
{
	if (start >= end)
		return;
	student mid = list[end];
	int left = start, right = end - 1;
	while (left<right)
	{
		while (list[left].total_score < mid.total_score && left < right)
			left++;
		while (list[right].total_score >= mid.total_score && left < right)
			right--;
		swap(list[left], list[right]);
	}
	if (list[left].total_score >= list[end].total_score)
		swap(list[left], list[end]);
	else
		left++;
	if (left)
		quick_sort_recursive(list, start, left - 1);
	quick_sort_recursive(list, left + 1, end);
}
void check_list(student list[], int len)
{
	for (int i = len-1; i > 0; i--)
	{
		if (list[i].total_score==list[i-1].total_score)
		{
			if (list[i].cheinese_score<list[i-1].cheinese_score)
				swap(list[i], list[i - 1]);
			else if (list[i].cheinese_score = list[i - 1].cheinese_score)
			{
				if (list[i].number>list[i-1].number)
					swap(list[i], list[i - 1]);
			}
		}
	}
}
void quick_sort(student list[],int len)
{
	quick_sort_recursive(list, 0, len - 1);
	check_list(list, len);
}
void schoolship(const char* file)
{
	std::fstream fs;
	std::vector<int> data;
	std::string line;
	fs.open(file, std::ios::in);
	if (!fs)
	{
		std::cout << "NO this fille" << std::endl;
		return;
	}
	while (std::getline(fs,line))
	{
		std::stringstream ss;
		ss << line;
		if (!ss.eof())
		{
			int temp;
			while (ss>>temp)
				data.push_back(temp);
		}
	}
	fs.close();
	std::vector<student> list(data[0]);
	student* p = &list[0];
	int i = 0;
	for (int i = 0; i < data[0]; i++)
	{
		list[i].number = i + 1;
		list[i].cheinese_score = data[1 + 3 * i];
		list[i].math_score = data[2 + 3 * i];
		list[i].english_score = data[3 + 3 * i];
		list[i].total_score = list[i].cheinese_score + list[i].math_score + list[i].english_score;
	}
	quick_sort(p, data[0]);
	for (int i = data[0]-1; i >data[0]-6; i--)
	{
		std::cout << list[i].number << " " << list[i].total_score << std::endl;
	}
}
#elif question==4
#include<iostream>
#include<fstream>
#include<vector>
void virus(const char* file)
{
	int lineage, column, cycle,number=0;
	std::fstream fs(file, std::ios::in);
	fs >> lineage >> column;
	std::vector<char> map((lineage+1) * column);
	char* p = &map[0];
	fs.get();
	for (int i = 0; i < (lineage+1)*column; i++)
	{
		fs.get(*p);
		p++;
	}
	fs>>cycle;
	fs.close();
	std::vector<int> loc((lineage + 1) * column);
	int* p_l = &loc[0];
	for (int i = 0; i < (lineage+1)*column; i++)
	{
		if (map[i] == 'X')
		{
			*p_l = i;
			number++;
		}
	}

	for (int i = 0; i < cycle; i++)
	{
		p_l = &loc[0];
		for (int j = 0; j < number; j++)
		{
			if ((p_l[j] - lineage) >= 0 && map[loc[j] - lineage] == 'O')
				map[loc[j] - lineage - 1] = 'X';
			if ((loc[j] + lineage) < ((lineage + 1) * column - 1) && map[loc[j] + lineage] == 'O')
				map[loc[j] + lineage + 1] = 'X';
			if ((loc[j] + 1) < ((lineage + 1) * column - 1) && map[loc[j] + 1] != '\0' && map[loc[j] + 1] == 'O')
					map[loc[j] + 1] = 'X';
			if ((loc[j] - 1) >= 0 && map[loc[j] - 1] != '\0' && map[loc[j] - 1] == 'O')
				map[loc[j] - 1] = 'X';
		}
		number = 0;
		for (int i = 0; i < (lineage + 1) * column; i++)
		{
			if (map[i]== 'X')
				number++;
		}
		p_l = &loc[0];
		for (int i = 0; i < (lineage + 1) * column; i++)
		{
			if (map[i] == 'X')
			{
				*p_l = i;
				p_l++;
			}
		}
	}
	for (int i = 0; i < (lineage+1)*column; i++)
	{
		std::cout << map[i];
	}
}
#elif question==5
#include <iostream>
#include <vector>

typedef struct Point {
	union 
	{
		int num;
		char signal;
	};
	bool type;
	Point* next;
}point;
typedef struct calc_temp {
	int num;
	char signal;
	calc_temp* next;
};
void change_type(Point* p, char* str)
{
	Point* q = p;
	char num[10] = { '\0' }; char* n = &num[0];
	while (true)
	{
		switch (*str)
		{
		case '+':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		case '-':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		case '*':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		case '/':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		case '(':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		case ')':
			p->signal = *str;
			str++;
			p->type = false;
			break;
		default:
			n = &num[0];
			while (*str >= '0' && *str <= '9')
			{
				*n = *str;
				n++; str++;
			}
			p->num = atoi(num);
			p->type = true;
			for (int i = 0; i < 10&&num[i]!='\0'; i++)
			{
				num[i] = '\0';
			}
			break;
		}
		if (*str=='\0')
			break;
		p->next = new Point;
		p = p->next;
		p->next = NULL;
	}
}
int calc(Point& p)
{
	calc_temp data; data.next = NULL;
	calc_temp* q = &data;
	while (true)
	{
		if (p.type==false)
		{
			if (p.signal == '(')
			{
				q->num = calc(*(p.next));
				p = *(p.next);
			}
			else if (p.signal == ')')
			{
				if (p.next != NULL)
					p = *(p.next);
				else
					break;
			}
			else
			{
				q->signal = p.signal;
				q->next = new calc_temp;
				q = q->next; q->next = NULL; q->signal = '\0';
				p = *(p.next);
			}
		}
		else
		{
			q->num = p.num;
			if (p.next != NULL)
				p = *(p.next);
			else
				break;
		}
	}
	q = &data;
	while (q->next != NULL)
	{
		if (q->signal == '/' || q->signal == '*')
		{
			if (q->signal == '/')
				q->num = q->num / q->next->num;
			else
				q->num = q->num * q->next->num;
			if (q->next->signal != '\0')
				q->signal = q->next->signal;
			else
				break;
			q->next = q->next->next;
		}
		else
			q = q->next;
	}
	*q = data;
	while (q->next != NULL)
	{
		if (q->signal == '+')
			q->num = q->num + q->next->num;
		else
			q->num = q->num - q->next->num;
		if (q->next->signal != '\0')
			q->signal = q->next->signal;
		else
			break;
		q->next = q->next->next;
	} 
	return data.num;
}
void stack(void)
{
	char str[100] = { '\0' };
	Point* p = new Point;
	p->next = NULL;
	std::cin >> str;
	str;
	change_type(p, str);
	std::cout<<calc(*p);
}
#elif question==6

#endif 