using System;

namespace AbstractFactory
{
    public interface IAfternoonTeaKitchen
    {
        ISweets MakeSweets();
        ITea MakeTea();
    }

    class TaiwaneseKitchen : IAfternoonTeaKitchen
    {
        public ISweets MakeSweets()
        {
            return new PineappleCake();
        }

        public ITea MakeTea()
        {
            return new Oolong();
        }
    }

    class EnglishKitchen : IAfternoonTeaKitchen
    {
        public ISweets MakeSweets()
        {
            return new Scone();
        }

        public ITea MakeTea()
        {
            return new Assam();
        }
    }

    public interface ISweets
    {
        string GetSweets();
    }

    class PineappleCake : ISweets
    {
        public string GetSweets()
        {
            return "pineapple cake";
        }
    }

    class Scone : ISweets
    {
        public string GetSweets()
        {
            return "scones";
        }
    }

    public interface ITea
    {
        string GetTea();
    }

    class Oolong : ITea
    {
        public string GetTea()
        {
            return "Oolong tea";
        }
    }

    class Assam : ITea
    {
        public string GetTea()
        {
            return "Assam tea";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Let's order a set of Taiwanese afternoon tea");
            ClientMethod(new TaiwaneseKitchen());
            Console.WriteLine();
            Console.WriteLine("Let's order a set of English afternoon tea");
            ClientMethod(new EnglishKitchen());
        }

        public void ClientMethod(IAfternoonTeaKitchen kitchen)
        {
            var sweets = kitchen.MakeSweets();
            var tea = kitchen.MakeTea();
            Console.WriteLine($"- Sweets: {sweets.GetSweets()}");
            Console.WriteLine($"- Tea: {tea.GetTea()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }

}
