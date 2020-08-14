using System;

namespace Singleton
{
    // Second version - simple thread-safety
    class SingletonV2SimpleThreadSafe : NumberGenerator
    {
        private static SingletonV2SimpleThreadSafe _instance = null;
        private static readonly object padlock = new object();
        private SingletonV2SimpleThreadSafe() { }

        public static SingletonV2SimpleThreadSafe CounterInstance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonV2SimpleThreadSafe();
                    }
                    return _instance;
                }
            }
        }
    }
}
