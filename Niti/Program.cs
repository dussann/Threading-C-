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
        static Thread[] nizTredova;

        private static void textSequential()
        {            
            Console.WriteLine("Thread runs++++");  
            Console.WriteLine("Thread ends----");           
        }

        private static void textSim()
        {
            Random rn = new Random();
            int n = rn.Next(0, 6);           
            Console.WriteLine("Running "+n+" seconds");           
            Console.WriteLine("Thread runs++++");
            Thread.Sleep(n * 1000);          
            Console.WriteLine("Thread ends----");

        }

        private static void textAutoReset()
        {
            objAuto.WaitOne();
            Console.WriteLine("start");
            Console.WriteLine("end");
            //objAuto.Set();
        }
        //prvi na drugi nacin
        static void AutoReset()
        {
            Console.WriteLine("Insert how many thrads do you want sequential (with 'AutoResetEvent')?");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                Thread t = new Thread(textAutoReset);
                t.Start();                
                Console.ReadKey();
                objAuto.Set();
            }

        }
        //prvi
        public static void CreateThreadsSequential()
        {
            Console.WriteLine("Insert how many thrads do you want to run sequential?");
            int number = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                Thread t = new Thread(textSequential);
                
                t.Name = i.ToString();
                t.Start();
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                Thread.Sleep(200);
                Console.WriteLine("Thread " + t.Name + " is running: " + t.IsAlive);
                Console.WriteLine();
            }
           
        }
        //drugi
        public static void CreateThreadsSim()
        {
            Console.WriteLine("Insert how many thrads do you want to run simultaneously?");

            int number = Convert.ToInt32(Console.ReadLine());
            nizTredova = new Thread[number];

            for (int j = 0; j < number; j++)
            {
                nizTredova[j] = new Thread(textSim);
                nizTredova[j].Start();
            }
            Thread checkThread = new Thread(Check);
            checkThread.Start();


        }

        private static void Check()
        {
            bool check = true;
            while (check)
            {
                Thread.Sleep(2000);
                for (int j = 0; j < nizTredova.Length; j++)
                {
                    if (nizTredova[j].IsAlive)
                    {                       
                        break;
                    }
                    if (!nizTredova[nizTredova.Length - 1].IsAlive)
                        check = false;                    
                }
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("All threads are finished");
        }
        
        
        static void Main(string[] args)
        {
            //prvi zad
            CreateThreadsSequential();
            // prvi zad drugi nacin
            AutoReset();

            //drugi
            CreateThreadsSim();

            Console.ReadKey();
        }
    }
}
