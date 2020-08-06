using System;

namespace Factory
{
    abstract class Bar
    {
        public abstract ICocktail MixSignalCocktail();
        public string GetSignalCocktail()
        {
            var product = MixSignalCocktail();
            return "Here's your " + product.Mix();
        }
    }
    class bLineByATrain : Bar
    {
        public override ICocktail MixSignalCocktail()
        {
            return new GinTonic();
        }
    }

    class cParkByATrain : Bar
    {
        public override ICocktail MixSignalCocktail()
        {
            return new Margarita();
        }
    }

    public interface ICocktail
    {
        string Mix();
    }

    class GinTonic : ICocktail
    {
        public string Mix()
        {
            return "Gin and Tonic!";
        }
    }

    class Margarita : ICocktail
    {
        public string Mix()
        {
            return "Margarita!";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("At bar 1...");
            ClientCode(new bLineByATrain());

            Console.WriteLine("At bar 2...");
            ClientCode(new cParkByATrain());
        }

        private void ClientCode(Bar bar)
        {
            Console.WriteLine("- Let's order a signal cocktail: " + bar.GetSignalCocktail());
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
