using System;

namespace Singleton
{
    // First version - not thread-safe
    class SingletonV1NotThreadSafe : NumberGenerator
    {
        // 用靜態欄位初始化 _instance 並不賦予值 (multithread 時會有問題)
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
