using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_21
{
    class Program
    {
        const int n = 2;
        const int m = 3;
        static int[,] garden = new int[n, m]
        {
            { 9, 2, 3, },
            { 3, 5, 8, }       
        };
        
        
        static void Main(string[] args)
        {
            Console.Write(garden);


            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(Gardener1);
            thread.Start();

            Gardener2();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{garden[i,j]}");
                }                
            }
            Console.ReadKey();
        }

        static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (garden[i,j] >= 0)
                    {
                        int delay = garden[i,j];
                        garden[i,j] = -1;
                        Thread.Sleep(delay);
                    }
                }
                    
            }
        }

        static void Gardener2()
        {
            for (int i = n-1; i >= 0; i--)
            {
                for (int j = m-1; j >= m; j--)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }

            }
        }




    }
}
