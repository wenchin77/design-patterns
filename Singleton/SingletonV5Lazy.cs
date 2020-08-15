using System;

namespace Singleton
{
    // using .NET 4's Lazy<T> type
    class SingletonV5Lazy : NumberGenerator
    {
        private static readonly Lazy<SingletonV5Lazy> lazy = new Lazy<SingletonV5Lazy>(() => new SingletonV5Lazy());
        public static SingletonV5Lazy CounterInstance => lazy.Value;
        private SingletonV5Lazy()
        {
        }
    }
}
