using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace dz_3
{
    class Alph
    {
        public List<char> a = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' };
        public char last = 'f';
        public char first = 'a';
        public char Change(char v)
        {
            if (v == last)
                v = first;
            else
            {
                for (int i = 0; i < a.Count - 1; i++)

                    if (a[i] == v)
                    {
                        v = a[i + 1];
                        break;
                    }
            }
            return v;
        }
    }
    class Program
    {

        static void nextCombobj(List<char> comb, Alph a)
        {
            for (int i = comb.Count - 1; i >= 0; i--)
            {
                if (comb[i] == a.last)
                {
                    comb[i] = a.first;
                }
                else
                {
                    comb[i] = a.Change(comb[i]);
                    break;
                }
            }
        }

        static bool hasnextCombobj(List<char> comb, char last)
        {
            string l = null;
            for (int i = 0; i < comb.Count; i++)
                l += last;
            string s = null;
            s = Vivod(comb, s);
            if (s == l)
                return false;
            else return true;
        }
        static string Vivod(List<char> a, string s)
        {
            for (int i = 0; i < a.Count; i++)
                s += a[i];
            return s;
        }
        static bool ras2(int [] a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] == 2)
                    return true;
            return false;
        } 
        static bool povtor(int [] a)
        {
            int k = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > 1)
                    k++;
            if (k > 1)
                return false;
            else return true;
        }
        static int[] mas(List<char> a)
        {
            int[] b = new int[6];

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == 'a')
                    b[0]++;
                if (a[i] == 'b')
                    b[1]++;
                if (a[i] == 'c')
                    b[2]++;
                if (a[i] == 'd')
                    b[3]++;
                if (a[i] == 'e')
                    b[4]++;
                if (a[i] == 'f')
                    b[5]++;
            }
            return b;
        }
        static bool proverka1(List<char> a)
        {
            int[] b = new int[6];
            b = mas(a);
            if (povtor(b) && ras2(b))
                return true;
            else return false;
        }
        static bool ras2_2(int[] a)
        {
            int y = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] == 2)
                    y++;
            if(y==2)        
               return true;
           else return false;
        }
        static bool povtor_2(int[] a)
        {
            int k = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > 1)
                    k++;
            if (k > 2)
                return false;
            else return true;
        }
        static bool proverka2(List<char> a)
        {
            int[] b = new int[6];
            b = mas(a);
            if (povtor_2(b) && ras2_2(b))
                return true;
            else return false;
        }
        static void Main(string[] args)
        {

            List<char> comb = new List<char> { 'a', 'a', 'a', 'a','a'};
            List<char> comb1 = new List<char> { 'a', 'a', 'a', 'a', 'a', 'a',};
            Alph a = new Alph();

            StreamWriter sw = new StreamWriter(@"C:\Users\Владислав\source\repos\dz\dz\dz_3\1.txt");
            StreamWriter rw = new StreamWriter(@"C:\Users\Владислав\source\repos\dz\dz\dz_3\2.txt");
            while (hasnextCombobj(comb, a.last))
            {
                string s = null;
                s = Vivod(comb, s);
                if (proverka1(comb))
                    sw.WriteLine("{0} ", s);
                nextCombobj(comb, a);
            }
            sw.Close();
            while (hasnextCombobj(comb1, a.last))
            {
                string s = null;
                s = Vivod(comb1, s);
                if (proverka2(comb1))
                    rw.WriteLine("{0} ", s);
                nextCombobj(comb1, a);
            }
            rw.Close();
            Console.WriteLine("Процесс Завершился!!!");
            Console.ReadKey();
        }

    }
}
