using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dz2DM
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
                    //continue;
                }
                else
                {
                    comb[i] = a.Change(comb[i]);
                    break;
                }
            }
        }

        static bool hasnextCombobj(List<char> comb)
        {
            string s = null;
            s = Vivod(comb, s);
            if (s == "fffff")
                return false;
            else return true;
        }
        static string Vivod(List<char> a, string s)
        {
            for (int i = 0; i < a.Count; i++)
                s += a[i];
            return s;
        }
        static bool povtor(List<char> a)
        {
            int[] povtori = new int[5];
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == 'b')
                    povtori[0]++;
                if (a[i] == 'c')
                    povtori[1]++;
                if (a[i] == 'd')
                    povtori[2]++;
                if (a[i] == 'e')
                    povtori[3]++;
                if (a[i] == 'f')
                    povtori[4]++;
            }
            for (int i = 0; i < 5; i++)
                if (povtori[i] > 1)
                    return false;
            return true;
        }
        static bool ka(List<char> a)
        {
            int k = 0;
            for (int i = 0; i < a.Count; i++)
                if (a[i] == 'a')
                    k++;
            if (k == 2)
                return true;
            else return false;
        }

        static void Main(string[] args)
        {

            List<char> comb = new List<char> { 'a', 'a', 'a', 'a', 'a' };
            Alph a = new Alph();

            StreamWriter sw = new StreamWriter(@"C:\Users\Владислав\source\repos\dz\dz\dz_2\1.txt");
            StreamWriter rw = new StreamWriter(@"C:\Users\Владислав\source\repos\dz\dz\dz_2\2.txt");
            while (hasnextCombobj(comb))
            {
                string s = null;
                s = Vivod(comb, s);
                if (ka(comb))
                    sw.WriteLine("{0} ", s);

                if (ka(comb) && povtor(comb))
                    rw.WriteLine("{0} ", s);
                nextCombobj(comb, a);
            }
            sw.Close();
            rw.Close();
            Console.WriteLine("Процесс Завершился!!!");
            Console.ReadKey();
        }
    }
}