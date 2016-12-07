using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = KMP("FSAQWadASDCXE","ASD");
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
        public static int KMP(string ts,string ps)
        {
            char[] t = ts.ToCharArray();
            char[] p = ps.ToCharArray();
            int i = 0;
            int j = 0;
            int[] next = getNext(ps);
            while(i < t.Length && j< p.Length)
            {
                if(j == -1 || t[i] == p[j]) //如果j = -1或者当前字符匹配成功
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j]; //如果j != -1且当前字符匹配失败
                }
            }
            if(j == p.Length)
            {
                return i - j;
            }
            else
            {
                return -1;
            }
        }
        public static int[] getNext(string ps)
        {
            char[] p = ps.ToCharArray();
            int[] next = new int[p.Length];
            next[0] = -1;
            int j = 0;
            int k = -1;
            while(j<p.Length - 1)
            {
                //p[k]表示前缀，p[j]表示后缀
                if(k == -1 || p[j] == p[k])
                {
                    if(p[++j] == p[++k])//当两个字符相等时要继续递归，k = next[k] = next[next[k]]
                    {
                        next[j] = next[k];
                    }
                    else
                    {
                        next[j] = k;
                    }
                }
                else
                {
                    k = next[k];
                }
            }
            return next;
        }
    }
}
