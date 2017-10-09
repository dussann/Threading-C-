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
        static AutoResetEvent objAuto = new AutoResetEvent(false);

        public static void text()
        {           
            Console.WriteLine("Thread runs");            
        }

        static void text1()
        {
            objAuto.WaitOne();
            Console.WriteLine("start");
            Console.WriteLine("end");

            //objAuto.Set();

        }


        static void init(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Thread t = new Thread(text1);
                t.Start();
                Console.ReadKey();
                objAuto.Set();
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

            // createThreadsSequential(number);

            init(number);
            Console.ReadKey();
        }
    }
}
