using System;

namespace Factory
{
    abstract class Bar
    {
        public abstract IMargarita MixMargarita();
        public string GetMargarita()
        {
            var drink = MixMargarita();
            return "Here's your " + drink.GetDrinkName();
        }
    }
    class BLineByATrain : Bar
    {
        public override IMargarita MixMargarita() => new StrongMargarita();
    }

    class CParkByATrain : Bar
    {
        public override IMargarita MixMargarita() => new SkinnyMargarita();
    }

    public interface IMargarita
    {
        string GetDrinkName();
    }

    class StrongMargarita : IMargarita
    {
        public string GetDrinkName() => "strong Margarita!";
    }

    class SkinnyMargarita : IMargarita
    {
        public string GetDrinkName() => "skinny Margarita!";
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("At B Line by a Train...");
            ClientCode(new BLineByATrain());

            Console.WriteLine("At C Park by a Train...");
            ClientCode(new CParkByATrain());
        }

        private void ClientCode(Bar bar)
        {
            Console.WriteLine("- Let's order a margarita");
            Console.WriteLine($"- {bar.GetMargarita()}");
            Console.WriteLine();
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
