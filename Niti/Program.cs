using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Niti
{
    class Program
    {
        static object lockObject = new object();

        public static void text()
        {
            lock (lockObject)
            {
                Console.WriteLine("Thread runs");
            }
        }

        public static void createThreadsSequential(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Thread t = new Thread(text);
                t.Name = i.ToString();
                t.Start();
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                t.Join();
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                Console.WriteLine();
            }
        }

        public static void createThreads(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Thread t = new Thread(text);
                t.Name = i.ToString();
                t.Start();
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                //t.Join();
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                if (t.IsAlive)
                {
                    Console.WriteLine("ziv je");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {

            
            Console.WriteLine("Insert how many thrads do you want?");
            int number = Convert.ToInt32(Console.ReadLine());

            createThreadsSequential(number);
            Console.ReadKey();
        }
    }
}
