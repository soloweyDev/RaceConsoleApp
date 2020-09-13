using System;
using System.Threading;

namespace RaceConsoleApp
{
    class Program
    {
        static int number = 0;
        static Random random = new Random();
        static void Main()
        {
            Thread[] threads = new Thread[5];

            for (int i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(Start));
                threads[i].Start();
            }
        }

        static void Start(object _)
        {
            int sleep = random.Next(50, 100);
            number++;
            Console.WriteLine($"number: {number}, sleep: {sleep}");
            Runner(number, sleep);
        }

        static void Runner(int number, int sleep)
        {
            for (int i = 0; i < 120; ++i)
            {
                Console.Write(number);
                Thread.Sleep(sleep);
            }

            Console.WriteLine($"\nnumber: {number} finished");
        }
    }
}
