using System;
using System.Threading;

namespace SingletonV2SimpleThreadSafe
{
    // Second version - simple thread-safety
    class CounterSingleton
    {
        private static CounterSingleton _instance;
        private int _counter = 0;
        private static readonly object padlock = new object();
        private static readonly object numberBlock = new object();
        private CounterSingleton() { }

        public static CounterSingleton CounterInstance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new CounterSingleton();
                    }
                    return _instance;
                }
            }
        }

        public int GetNumber()
        {
            lock (numberBlock)
            {
                _counter++;
                return _counter;
            }
        }
    }

    class Program
    {
        static void BookOnThread1()
        {
            for (int i = 0; i < 10; i++)
            {
                CounterSingleton webCounter = CounterSingleton.CounterInstance;
                Console.WriteLine($"Booking number on web: {webCounter.GetNumber()}");
            }
        }

        static void BookOnThread2()
        {
            for (int i = 0; i < 10; i++)
            {
                CounterSingleton appCounter = CounterSingleton.CounterInstance;
                Console.WriteLine($"Booking number on app: {appCounter.GetNumber()}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Booking on multiple threads (thread-safe):");
            Thread t1 = new Thread(BookOnThread1);
            Thread t2 = new Thread(BookOnThread2);
            t1.Start();
            t2.Start();
        }
    }
}
