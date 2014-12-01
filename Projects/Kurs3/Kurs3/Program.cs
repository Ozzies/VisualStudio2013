using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs3
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 3;
            int[] rangMet = { 3, 5, 4, 1, 2 };
            byte[] wMax = { 1, 1, 1, 0, 0 };
            double[] cnorm = new double[5];
            string[][] koef ={
                                new[] {"33","6.6","2.4"},
                                new[] {"26","14,95","27,5"},
                                new[] {"7,8","2.53","4.602"},
                                new[] {"5.5","3.3","0.66"},
                                new[] {"2","1","2"}
                            };

            var pok = new double[n];
            var koef2 = new double[5][];
            for (int i = 0; i < 5; i++)
            {
                koef2[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    koef2[i][j] = double.Parse(koef[i][j].Replace('.', ','));
                }
            }

            var rang = new double[5, n];
            Ranking(koef2, ref rang, wMax, n);
            Normir(rangMet, ref cnorm);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    pok[i] += cnorm[j]*rang[j,i];
                }
            }
            Console.ReadLine();
        }

        static void Ranking(double[][] koef, ref double[,] rang, byte[] wMax, int n)
        {
            for (int i = 0; i < 5; i++)
            {
                if (wMax[i] == 1)
                {
                    var sum = 0d;
                    for (int j = 0; j < n; j++) sum += koef[i][j];
                    for (int j = 0; j < n; j++) rang[i, j] = koef[i][j] / sum;
                }
                else
                {
                    var sum = 0d;
                    for (int j = 0; j < n; j++) sum += (1 / koef[i][j]);
                    for (int j = 0; j < n; j++) rang[i, j] = (1 / koef[i][j]) / sum;
                }
            }
        }

        static void Normir(int[] rangMet, ref double[] cnorm)
        {
            int n = rangMet.Length;
            var c = new double[n];
            var csum = 0d;
            for (var j = 0; j < n; j++)
            {
                c[j] = 1 - (rangMet[j] - 1) / (double)n;
                csum += c[j];
            }
            for (int j = 0; j < n; j++) cnorm[j] = c[j] / csum;
        }
    }
}
