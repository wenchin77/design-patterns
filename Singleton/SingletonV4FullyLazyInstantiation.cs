namespace Singleton
{

    class SingletonV4FullyLazyInstantiation : NumberGenerator
    {
        private SingletonV4FullyLazyInstantiation() { }
        public static SingletonV4FullyLazyInstantiation CounterInstance => Nested.instance;

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly SingletonV4FullyLazyInstantiation instance = new SingletonV4FullyLazyInstantiation();
        }
    }
}