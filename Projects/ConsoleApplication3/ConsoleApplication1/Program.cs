using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[20];
            int min = 0;
            int max = 0;

            Random rnd = new Random();
            Console.WriteLine("\t\t\t      Оригинальный массив\n");
            for (int i = 1; i < iArray.Length; i++)
            {
                iArray[i] = rnd.Next(-30, 30);
                Console.Write("\t{0,3}\t", iArray[i]);
                if (iArray[min] > iArray[i])
                    min = i;
                if (iArray[max] < iArray[i])
                    max = i;
            }
            int tmp = iArray[min];
            iArray[min] = iArray[max];
            iArray[max] = tmp;
            Console.ReadKey();
        }
    }
}
