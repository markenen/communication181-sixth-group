#include <Windows.h>
#include <iostream>
#include <vector>
#include <String>
#include <stack>
#include <cstdlib>
using namespace std;
int main()
{
	string str_in;
	vector<string> houzhuibiaodashi;			//后缀表达式
	stack<char> CStack;
	string temp;			//临时
	stack <float> NStack;
	while (1)
	{
		houzhuibiaodashi.clear();			//后缀表达式向量清空
		while (!CStack.empty())				//运算符栈清空
		{
			CStack.pop();
		}
		temp = "";							//表达式清空
		while (!NStack.empty())				//数值栈清空
		{
			NStack.pop();
		}
		cout << "请输入多项式：";
		cin >> str_in;
		for (int i = 0; i < str_in.length(); i++)
		{
			if (str_in[i] == '(')		//小括号直接入运算符栈
			{
				CStack.push(str_in[i]);				//运算符入栈
			}
			else if (str_in[i] >= '0' && str_in[i] <= '9')			//处理数字
			{
				temp = str_in[i];
				while (str_in[i + 1] >= '0' && str_in[i + 1] <= '9' && i < str_in.length())
				{
					temp += str_in[++i];
				}
				houzhuibiaodashi.push_back(temp);				//数字推入后缀表达式
			}

			else if (
				(str_in[i] == '-'
					&& (i > 0 && !(str_in[i - 1] >= '0' && str_in[i - 1] <= '9' && str_in[i + 1] >= '0' && str_in[i + 1] <= '9'))	//排除num-num型减法
					&& (i > 0 && !(str_in[i - 1] == ')' && str_in[i + 1] >= '0' && str_in[i + 1] <= '9'))	//排除（）-num型减法
					&& (i > 0 && !(str_in[i + 1] == ')' && str_in[i - 1] >= '0' && str_in[i - 1] <= '9')))	//排除num-（）型减法
				|| (str_in[i] == '-' && i == 0)										//加入负数在多项式开头的情况
				)//处理负数，不能处理-（3+2）这种
			{
				temp = "";

				temp = str_in[i++];
				while (str_in[i] >= '0' && str_in[i] <= '9' && i < str_in.length())
				{
					temp += str_in[i];
					i++;
				}

				houzhuibiaodashi.push_back(temp);				//数字推入后缀表达式

				i--;			//防止指针过度移动。上一个版本的下一个分支直接用了if，不是else if ， 虽然能解决这个问题但是不严谨

			}
			else if (str_in[i] == '-' && str_in[i + 1] == '(' && (i == 0))		//处理-（3+2）在开头的多项式
			{


				houzhuibiaodashi.push_back("-1");			//改成-1 * （5+2） 进行计算，先压入-1，之后按照*规则处理


				while (!CStack.empty() && (CStack.top() == '*' || CStack.top() == '/'))
				{
					temp = "";
					temp = CStack.top();
					CStack.pop();
					houzhuibiaodashi.push_back(temp);
				}
				CStack.push('*');
			}



			else if (str_in[i] == ')')
			{
				temp = "";
				while (!CStack.empty() && CStack.top() != '(')
				{
					temp = "";
					temp = CStack.top();
					houzhuibiaodashi.push_back(temp);
					CStack.pop();
				}
				CStack.pop();			//(出栈
			}

			else if (str_in[i] == '+' || str_in[i] == '-' || str_in[i] == '*' || str_in[i] == '/')
			{
				temp = "";
				if (str_in[i] == '+' || str_in[i] == '-')
				{
					while (!CStack.empty() && (CStack.top() == '+' || CStack.top() == '-' || CStack.top() == '*' || CStack.top() == '/'))
					{
						temp = "";
						temp = CStack.top();
						CStack.pop();
						houzhuibiaodashi.push_back(temp);
					}
					CStack.push(str_in[i]);
				}
				else if (str_in[i] == '*' || str_in[i] == '/')
				{
					while (!CStack.empty() && (CStack.top() == '*' || CStack.top() == '/'))
					{
						temp = "";
						temp = CStack.top();
						CStack.pop();
						houzhuibiaodashi.push_back(temp);
					}
					CStack.push(str_in[i]);
				}

			}




		}


		while (!CStack.empty())
		{
			temp = CStack.top();
			CStack.pop();
			houzhuibiaodashi.push_back(temp);
		}
		int i = 0;
		float num1, num2;
		while (!houzhuibiaodashi.empty() && i < houzhuibiaodashi.size())
		{
			if (houzhuibiaodashi[i] == "+")
			{
				num1 = NStack.top();
				NStack.pop();
				num2 = NStack.top();
				NStack.pop();
				NStack.push(num1 + num2);
			}
			else if (houzhuibiaodashi[i] == "-")
			{
				if (i == 0)				//检测到负号时可能是负数
				{
					char* data = new char[houzhuibiaodashi.size()];
					for (int t = 1; t < houzhuibiaodashi[i].size(); t++)
					{
						data[t] = houzhuibiaodashi[i][t];
					}

					NStack.push(0 - atoi(data));
				}
				else
				{
					num1 = NStack.top();
					NStack.pop();
					num2 = NStack.top();
					NStack.pop();
					NStack.push(num2 - num1);
				}
			}
			else if (houzhuibiaodashi[i] == "*")
			{
				num1 = NStack.top();
				NStack.pop();
				num2 = NStack.top();
				NStack.pop();
				NStack.push(num1 * num2);
			}
			else if (houzhuibiaodashi[i] == "/")
			{
				num1 = NStack.top();
				NStack.pop();
				num2 = NStack.top();
				NStack.pop();
				NStack.push(num2 / num1);
			}
			else
			{
				char* data = new char[houzhuibiaodashi.size()];
				for (int t = 0; t < houzhuibiaodashi[i].size(); t++)
				{
					data[t] = houzhuibiaodashi[i][t];
				}

				NStack.push(atoi(data));
			}

			i++;
		}
		cout << "等式的值为" << NStack.top() << endl;
	}
	system("pause");
}
