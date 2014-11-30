using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            int[] r = { 1, 3, 2, 4, 5 };
            string[,] koef ={
                                {"557,9","603,3","561,0","356,8"},
                                {"1,46","1,5","1,47","1,3"},
                                {"22,7","25","27,1","25,3"},
                                {"4,0","4,0","3,0","2,0"},
                                {"55,0","53,3","45","28,3"}
                            };


            //        doit(r);


            Console.WriteLine(koef[1, 2]);
            a = Convert.ToDouble(koef[1, 2].Replace('.', ','));
            Console.WriteLine(a);

            Console.ReadLine();



        }

        static void doit(int[] r)
        {
            int csum = 0;
            int[] c = new int[r.Length];
            int[] cn = new int[r.Length];
            for (int j = 0; j < c.Length; j++)
            {
                c[j] = 1 - (r[j] - 1) / (r.Length);
                csum += c[j];
            }
            for (int j = 0; j < c.Length; j++) cn[j] = c[j] / csum;

        }
    }
}
