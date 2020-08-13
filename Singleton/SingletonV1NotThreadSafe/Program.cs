using System;
using System.Threading;

namespace SingletonV1NotThreadSafe
{
    // First version - not thread-safe
    class CounterSingleton
    {
        // 用靜態欄位初始化 _instance 並不賦予值 (multithread 時會有問題)
        private static CounterSingleton _instance;
        private int _counter = 0;
        private static readonly object numberBlock = new object();

        // 建構子設為 private 避免外面可以直接 new 一個物件的情況
        private CounterSingleton() { }

        public static CounterSingleton CounterInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CounterSingleton();
                }
                return _instance;
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
            for (int i = 0; i < 5; i++)
            {
                CounterSingleton webCounter = CounterSingleton.CounterInstance;
                Console.WriteLine($"Booking number on web: {webCounter.GetNumber()}");
            }
        }

        static void BookOnThread2()
        {
            for (int i = 0; i < 5; i++)
            {
                CounterSingleton appCounter = CounterSingleton.CounterInstance;
                Console.WriteLine($"Booking number on app: {appCounter.GetNumber()}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Case 1: booking on the same thread:");
            CounterSingleton webCounter = CounterSingleton.CounterInstance;
            Console.WriteLine($"Booking number on web: {webCounter.GetNumber()}");
            CounterSingleton appCounter = CounterSingleton.CounterInstance;
            Console.WriteLine($"Booking number on app: {appCounter.GetNumber()}");
            Console.WriteLine($"Booking number on web: {webCounter.GetNumber()}");

            // Console.WriteLine("Case 2: booking on multiple threads (not thread-safe):");
            // Thread t1 = new Thread(BookOnThread1);
            // Thread t2 = new Thread(BookOnThread2);
            // t1.Start();
            // t2.Start();
        }
    }
}
