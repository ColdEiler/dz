using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace dz_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string graph1 = null;
            string graph2 = null;

            graph1 = File.ReadAllText(@"C:\Users\Владислав\source\repos\dz\dz\dz_8\1.txt");
            graph2 = File.ReadAllText(@"C:\Users\Владислав\source\repos\dz\dz\dz_8\2.txt");

            if (graph1 == graph2)
                Console.WriteLine("Подстановка является автоморфизмом");
            else Console.WriteLine("Подстановка не является автоморфизмом");
            Console.ReadKey();
        }
    }
}
