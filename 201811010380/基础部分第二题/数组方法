//第二题数组方法
#include<stdio.h>
#define MaxSize 100
void monkey(int m,int n)
{
    int p[MaxSize];
    int i,j,t;
    for(i=0;i<m;i++) //在没有猴子离开圆圈的时候，猴子分布在序列0到m-1
        p[i]=i+1;   //每离开一个猴子，从后面一个编号重新计数
    t=0;
    printf("猴子离开的顺序： ");
    for(i=m;i>=1;i--)   //所有的猴子依次离开，直到最后只剩下一只猴子
    {
        t=(t+n-1)%i;//标记出圈猴子的位置，在新的序列的末尾可以到达新的计数点
        printf("%d",p[t]); //出圈猴子的序号
        for(j=i+1;j<=1;j++) //出圈的猴子被剔除，新的序列从被提出猴子的下一个开始计算
            p[j-1]=p[j];
    }
    printf("\n");
}

int main(void)
{
    int m,n;
    printf("请输入猴子的个数：");
    scanf("%d",&m);
    printf("请输入想要计数的位置：");
    scanf("%d",&n);
    monkey(m,n);
    return 0;
}
