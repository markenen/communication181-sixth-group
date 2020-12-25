#include<iostream>
#include<ostream>
using namespace std;
int getcount(int* p, int m, int n);
int main()
{
    int* p;
    int m, n, i;
    cout << "猴子的数量 m 为:" << endl;
    cin >> m;
    cout << "数到退场的数 n 为:" << endl;
    cin >> n;
    p = (int*)malloc(sizeof(int) * m);
    for (i = 0; i < m; i++)
        p[i] = i + 1;
    cout << "猴王的编号为:" << getcount(p, m, n) << endl;
    free(p);
    return 0;
}
int getcount(int* p, int m, int n)
{
    int i, temp, flag, count;
    temp = 0;
    count = m;
    while (count != 1)
    {
        flag = 1;
        while (flag < n)
        {
            if (temp >= m)
                temp = 0;
            if (p[temp] != 0)
            {
                flag++;
            }
            temp++;
        }
        if (temp >= m)
            temp = 0;
        while (temp < m && p[temp] == 0)
        {
            temp++;
            if (temp >= m)
                temp = 0;
        }
        p[temp] = 0;
        count -= 1;
    }
    for (i = 0; i < m; i++)
    {
        if (p[i] != 0)
        {
            return p[i];
        }
    }
}
