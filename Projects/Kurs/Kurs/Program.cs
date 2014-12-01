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
            int[] rangMet = { 1, 3, 2, 4, 5 };
            bool[] wMax = { true, true, true, false, true };
            string[][] koef ={
                                new[] {"557,9","603,3","561,0","356,8"},
                                new[] {"1,46","1,5","1,47","1,3"},
                                new[] {"22,7","25","27,1","25,3"},
                                new[] {"4,0","4,0","3,0","2,0"},
                                new[] {"55,0","53,3","45","28,3"}
                            };
            int[,] koefNumRang = new int[koef.Length, koef[1].Length];
            var koef2 = new double[5][];
            for (int i = 0; i < koef.Length; i++)
            {
                koef2[i] = new double[koef[i].Length];
                for (int j = 0; j < koef[i].Length; j++)
                {
                    koef2[i][j] = double.Parse(koef[i][j]);
                    koefNumRang[i, j] = j + 1;
                }
            }


            var koef3 = koef2;
            for (int i = 0; i < koef.Length; i++)
            {
                while (true)
                {
                    var f = false;
                    if (wMax[i])
                    {
                        for (int j = 0; j < koef3[i].Length - 1; j++)
                        {
                            if (!(koef3[i][j] > koef3[i][j + 1])) continue;
                            var temp = koef3[i][j + 1];
                            koef3[i][j + 1] = koef3[i][j];
                            koef3[i][j] = temp;
                            var temp2 = koefNumRang[i, j + 1];
                            koefNumRang[i, j + 1] = koefNumRang[i, j];
                            koefNumRang[i, j] = temp2;
                            f = true;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < koef3[i].Length - 1; j++)
                        {
                            if (!(koef3[i][j] < koef3[i][j + 1])) continue;
                            var temp = koef3[i][j + 1];
                            koef3[i][j + 1] = koef3[i][j];
                            koef3[i][j] = temp;
                            var temp2 = koefNumRang[i, j + 1];
                            koefNumRang[i, j + 1] = koefNumRang[i, j];
                            koefNumRang[i, j] = temp2;
                            f = true;
                        }

                    }

                    if (f == false) break;
                }
            }

            int[,] koefRang = new int[koef.Length, koef[1].Length];
            for (int i = 0; i < koef.Length; i++)
            {
                var temp = 4;
                for (int j = 0; j < koef[i].Length; j++)
                {
                    koefRang[i, koefNumRang[i, j]-1] = temp--;
                }
            }
            


            Console.ReadLine();


            //a = Convert.ToDouble(koef[1, 2].Replace('.', ','));
        }


        static void doit(int[] rang)
        {
            int csum = 0;
            int[] c = new int[rang.Length];
            int[] cn = new int[rang.Length];
            for (int j = 0; j < c.Length; j++)
            {
                c[j] = 1 - (rang[j] - 1) / (rang.Length);
                csum += c[j];
            }
            for (int j = 0; j < c.Length; j++) cn[j] = c[j] / csum;

        }
    }
}
