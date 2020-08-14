using System;

namespace Singleton
{
    class NumberGenerator
    {
        private int _counter = 0;
        private static readonly object numberBlock = new object();
        public int GetNumber()
        {
            lock (numberBlock)
            {
                _counter++;
                return _counter;
            }
        }
    }
}