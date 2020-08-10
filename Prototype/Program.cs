using System;

namespace Prototype
{
    public class FlowerBouquetDelivery
    {
        public int Id;
        public string ReceiverName;
        public BouquetInfo BouquetInfo;

        public FlowerBouquetDelivery ShallowCopy()
        {
            return (FlowerBouquetDelivery)this.MemberwiseClone();
        }

        public FlowerBouquetDelivery DeepCopy()
        {
            FlowerBouquetDelivery clone = (FlowerBouquetDelivery)this.MemberwiseClone();
            clone.BouquetInfo = new BouquetInfo(BouquetInfo.FlowerNum, BouquetInfo.FlowerType, BouquetInfo.Message);
            clone.ReceiverName = String.Copy(ReceiverName);
            return clone;
        }
    }

    public class BouquetInfo
    {
        public int FlowerNum;
        public string FlowerType;
        public string Message;

        public BouquetInfo(int flowerNum, string flowerType, string message)
        {
            this.FlowerNum = flowerNum;
            this.FlowerType = flowerType;
            this.Message = message;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FlowerBouquetDelivery originalBouquet = new FlowerBouquetDelivery();
            originalBouquet.Id = 6969;
            originalBouquet.ReceiverName = "Lily";
            originalBouquet.BouquetInfo = new BouquetInfo(520, "lilies", "親愛的 Lily, 可愛不是長久之計，可愛我是長久之計。");

            Console.WriteLine("花店製作你預定的花束，並進行深拷貝與淺拷貝，讓你當作未來的花束。原本的花束則作為模板給未來的花束用...\n");
            Console.WriteLine("原始花束 (模板):");
            DisplayValues(originalBouquet);

            FlowerBouquetDelivery bouquetShallowCopied = originalBouquet.ShallowCopy();
            FlowerBouquetDelivery bouquetDeepCopied = originalBouquet.DeepCopy();

            // Change the value of firstBouquet properties
            Console.WriteLine("花店接了別人生意，更新模板花束...\n");
            originalBouquet.Id = 8787;
            originalBouquet.ReceiverName = "Rose";
            originalBouquet.BouquetInfo.FlowerNum = 99;
            originalBouquet.BouquetInfo.FlowerType = "roses";
            originalBouquet.BouquetInfo.Message = "親愛的 Rose, 沒有水的地方叫沙漠，沒有你的地方叫寂寞。";

            Console.WriteLine("更新後的模板花束:");
            DisplayValues(originalBouquet);

            Console.WriteLine("花店送出先前為你複製好的的花束...\n");

            Console.WriteLine("在更新模板前淺拷貝的花束:");
            DisplayValues(bouquetShallowCopied);

            Console.WriteLine("在更新模板前深拷貝的花束:");
            DisplayValues(bouquetDeepCopied);
        }

        public static void DisplayValues(FlowerBouquetDelivery f)
        {
            Console.WriteLine($"- ID: {f.Id}");
            Console.WriteLine($"- Bouquet Info: {f.BouquetInfo.FlowerNum} {f.BouquetInfo.FlowerType}, '{f.BouquetInfo.Message}'");
            Console.WriteLine($"- Receiver Name: {f.ReceiverName}");
            Console.WriteLine();
        }
    }
}
