//链表法
#include<iostream>
#include<ostream>
#include <iostream>
using namespace std;
struct Monkey
{
    int num;  //猴子的编号
    struct Monkey* next; //下一只猴子
};

int main()
{
    int m, n, i, j, king;
    Monkey* head, * p1, * p2;
    cin >> m >> n;
    if (n == 1)
    {
        king = m;
    }
    else
    {
        //建立猴子围成的圆圈
        p1 = p2 = new Monkey;
        head = p1;
        p1->num = 1;
        for (i = 1; i < m; i++)  //其余m-1只猴子
        {
            p1 = new Monkey;  //p1是新增加的
            p1->num = i + 1;
            p2->next = p1;
            p2 = p1;          //p2总是上一只
        }
        p2->next = head;      //最后一只再指向第一只，成了一个圆圈

        //下面要开始数了
        p1 = head;
        for (i = 1; i < m; i++)  //循环m-1次，淘汰m-1只猴子
        {
            //从p1开始，数n-1只就找到第n只了
            for (j = 1; j < n - 1; j++)  //实际先找到第n-1只，下一只将是被淘汰的
                p1 = p1->next;    //围成圈的，可能再开始从第一只数，如果还未被淘汰的话

            //找到了，
            p2 = p1->next;  //p2将被删除
            //cout<<"第"<<i<<"轮淘汰"<<p2->num<<endl;   //可以这样观察中间结果
            p1->next = p2->next;  //p2就这样被“架空了”
            p1 = p2->next;  //下一轮数数的新起点
            delete p2;  //将不在链表中的结点放弃掉
        }
        king = p1->num;
        delete p1;
    }
    cout << king << endl;
    return 0;
}




//数组法
#include <iostream>
using namespace std;

int main()
{
    int N, K = 1, M, p;
    cin >> M >> N;
    if (N == 1)
    {
        p = (M + 1);
    }
    else
    {
        int* a = new int[M + 1];
        fill(a, a + M + 1, 0);

        //num为约瑟夫环剩余人数，count为所报数
        p = K;
        int  count = 0, num = M;
        while (num)
        {
            //未出环的猴子参与报数，当count是N时出环
            if (a[p] != -1 && ++count == N)
            {
                count = 0;
                a[p] = -1; //将已出环的人标记为-1
                num--;

            }

            p++;                 //指针指向下一个人
            p = (p - 1) % M + 1; //p范围转成[1,M]

        };
    }

    cout << "猴子大王是：" << p - 1 << " ";
    return 0;

}
