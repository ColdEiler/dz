using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dz_12
{
    class Program
    {
        static void nextCombobj(ref int[,] comb, int n)
        {
            for (int i = n - 1; i >= 0; i--)
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i < j)
                    {
                        if (comb[i, j] == 1)
                        {
                            comb[i, j] = 0;
                            comb[j, i] = 0;
                        }
                        else
                        {
                            comb[i, j] = 1;
                            comb[j, i] = 1;
                            return;
                        }
                    }
                }
        }
        static void Vivod(int[,] comb, int n, StreamWriter sr)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sr.Write("{0} ", comb[i, j]);
                sr.WriteLine();
            }
        }
        static int f(int n)
        {
            int p = 1;
            for (int i = 1; i <= n; i++)
                p *= i;
            return p;
        }
        static int sochet(int n, int k)
        {
            return f(n) / (f(n - k) * f(k));
        }
        static void y(ref int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i < j)
                    {
                        a[i, j] = 1;
                        a[j, i] = 1;
                    }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите порядок графа");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] comb = new int[n, n];
            int[,] proverka = new int[n, n];
            StreamWriter sw = new StreamWriter(@"C:\Users\Владислав\source\repos\dz\dz\dz_12\1.txt");
            int k = 0;
            while (k != Math.Pow(2, sochet(n, 2)))
            {
                Vivod(comb, n, sw);
                sw.WriteLine();
                nextCombobj(ref comb, n);
                k++;
            }
            sw.Close();
            Console.WriteLine("Все готово!!!");
            Console.ReadKey();
        }
    }
}
