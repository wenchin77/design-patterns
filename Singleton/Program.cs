using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        private enum SingletonType
        {
            NonThreadSafe = 1,
            SimpleThreadSafe = 2,
            ThreadSafeWithoutLocks = 3,
            FullyLazyInstantiation = 4,
            Lazy = 5,
        }

        static void V1BookOnThread1()
        {
            for (int i = 0; i < 5; i++)
            {
                SingletonV1NotThreadSafe webCounter = SingletonV1NotThreadSafe.CounterInstance;
                Console.WriteLine($"Booking number on web: {webCounter.GetNumber()}");
            }
        }

        static void V1BookOnThread2()
        {
            for (int i = 0; i < 5; i++)
            {
                SingletonV1NotThreadSafe appCounter = SingletonV1NotThreadSafe.CounterInstance;
                Console.WriteLine($"Booking number on app: {appCounter.GetNumber()}");
            }
        }

        static void MakeBookings(SingletonType singletonType, string channel)
        {
            NumberGenerator counter = null;
            switch (singletonType)
            {
                case SingletonType.NonThreadSafe:
                    counter = SingletonV1NotThreadSafe.CounterInstance;
                    break;
                case SingletonType.SimpleThreadSafe:
                    counter = SingletonV2SimpleThreadSafe.CounterInstance;
                    break;
                case SingletonType.ThreadSafeWithoutLocks:
                    counter = SingletonV3ThreadSafeWithoutLocks.CounterInstance;
                    break;
                case SingletonType.FullyLazyInstantiation:
                    counter = SingletonV4FullyLazyInstantiation.CounterInstance;
                    break;
                case SingletonType.Lazy:
                    counter = SingletonV5Lazy.CounterInstance;
                    break;
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Booking on {channel} with {singletonType}: {counter.GetNumber()}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Case 1: booking on the same thread:");
            MakeBookings(SingletonType.NonThreadSafe, "web");
            MakeBookings(SingletonType.NonThreadSafe, "app");

            // Console.WriteLine("Case 2: booking on multiple threads (not thread-safe):");
            // Thread t1 = new Thread(V1BookOnThread1);
            // Thread t2 = new Thread(V1BookOnThread2);
            // t1.Start();
            // t2.Start();

            Console.WriteLine("-----");

            MakeBookings(SingletonType.SimpleThreadSafe, "web");
            MakeBookings(SingletonType.SimpleThreadSafe, "app");

            Console.WriteLine("-----");

            MakeBookings(SingletonType.FullyLazyInstantiation, "web");
            MakeBookings(SingletonType.FullyLazyInstantiation, "app");

            Console.WriteLine("-----");

            MakeBookings(SingletonType.Lazy, "web");
            MakeBookings(SingletonType.Lazy, "app");
        }
    }
}
