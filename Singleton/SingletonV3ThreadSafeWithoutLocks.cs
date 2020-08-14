using System;
using System.Threading;

namespace Singleton
{
    // Fourth version - not quite as lazy, but thread-safe without using locks
    class SingletonV3ThreadSafeWithoutLocks : NumberGenerator
    {
        private static SingletonV3ThreadSafeWithoutLocks _instance = new SingletonV3ThreadSafeWithoutLocks();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SingletonV3ThreadSafeWithoutLocks() { }
        private SingletonV3ThreadSafeWithoutLocks() { }

        public static SingletonV3ThreadSafeWithoutLocks CounterInstance
        {
            get
            {
                return _instance;
            }
        }
    }
}
