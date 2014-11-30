using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void drowRectangle (int h, int w)
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 14; i++)
            {
                drowRectangle(3, i);
                
            }

            Console.ReadKey();
        }
        
    }
}
