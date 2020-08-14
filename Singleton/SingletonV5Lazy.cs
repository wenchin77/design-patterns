using System;

namespace Singleton
{
    // Sixth version - using .NET 4's Lazy<T> type
    class SingletonV5Lazy : NumberGenerator
    {
        private static SingletonV5Lazy _instance;
        private static readonly object padlock = new object();
        private SingletonV5Lazy() { }

        public static SingletonV5Lazy CounterInstance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonV5Lazy();
                    }
                    return _instance;
                }
            }
        }
    }
}
