using System;

namespace Factory
{
    abstract class Bar
    {
        public abstract ICocktail MixSignalCocktail();
        public string GetSignalCocktail()
        {
            var drink = MixSignalCocktail();
            return "Here's your " + drink.GetDrinkName();
        }
    }
    class BLineByATrain : Bar
    {
        public override ICocktail MixSignalCocktail()
        {
            return new GinTonic();
        }
    }

    class CParkByATrain : Bar
    {
        public override ICocktail MixSignalCocktail()
        {
            return new Margarita();
        }
    }

    public interface ICocktail
    {
        string GetDrinkName();
    }

    class GinTonic : ICocktail
    {
        public string GetDrinkName()
        {
            return "Gin and Tonic!";
        }
    }

    class Margarita : ICocktail
    {
        public string GetDrinkName()
        {
            return "Margarita!";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("At bar 1...");
            ClientCode(new BLineByATrain());

            Console.WriteLine("At bar 2...");
            ClientCode(new CParkByATrain());
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
