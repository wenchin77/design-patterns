using System;

namespace Singleton
{
    class SingletonV1NotThreadSafe : NumberGenerator
    {
        private static SingletonV1NotThreadSafe _instance = null;

        // 建構子設為 private 避免外面可以直接 new 一個物件的情況
        private SingletonV1NotThreadSafe() { }

        public static SingletonV1NotThreadSafe CounterInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonV1NotThreadSafe();
                }
                return _instance;
            }
        }
    }
}
