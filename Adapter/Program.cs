using System;

namespace Adapter
{
    public interface ITranslationTarget
    {
        string GetTranslation(string phrase);
    }

    class DoMeAFavorPhrases
    {
        public string RequestForARide() => "可以載我嗎？";
        public string RequestForFood() => "我想吃一口！";
        public string RequestForCompany() => "陪我。";
        public string RequestForFoodDelivery() => "買宵夜給我吃。";
        public string RequestForPhotos() => "幫我拍一百張美照！";
    }

    class PhraseAdapter : ITranslationTarget
    {
        private readonly DoMeAFavorPhrases _adaptee;
        public PhraseAdapter(DoMeAFavorPhrases adaptee)
        {
            this._adaptee = adaptee;
        }
        public string GetTranslation(string phrase)
        {
            switch (phrase)
            {
                case string x when (x.Contains("開車") || x.Contains("騎車")):
                    return _adaptee.RequestForARide();
                case string x when (x.Contains("無聊") || x.Contains("沒事")):
                    return _adaptee.RequestForCompany();
                case string x when (x.Contains("餓") && x.Contains("晚")):
                    return _adaptee.RequestForFoodDelivery();
                case string x when (x.Contains("拍照") || x.Contains("好美")):
                    return _adaptee.RequestForPhotos();
                case string x when x.Contains("好吃"):
                    return _adaptee.RequestForFood();
                default:
                    return "(無此翻譯)";
            }
        }
    }

    class Program
    {
        static DoMeAFavorPhrases doMeAFavorPhrases = new DoMeAFavorPhrases();
        static ITranslationTarget targetLanguage = new PhraseAdapter(doMeAFavorPhrases);
        static void Translate(string phrase)
        {
            Console.WriteLine();
            Console.WriteLine($"原始句子: {phrase}");
            Console.WriteLine($"翻譯句子: {targetLanguage.GetTranslation(phrase)}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("工具人語言翻譯機");
            Translate("你要開車嗎？");
            Translate("你會騎車去嗎？");
            Translate("這看起來好好吃喔！");
            Translate("好無聊。");
            Translate("肚子餓但好晚了喔...。");
            Translate("這裡好美喔！");
        }
    }
}
