using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {

        static void sort()
        {

            Random rnd = new Random();

            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 25);
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();

            bool f = false;
            int temp = array[0];

            while (true)
            {
                f = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        f = true;
                    }


                }

                if (f == false) break;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.ReadKey();

        }
        static void Main(string[] args)
        {
            sort();
        }
    }
}
