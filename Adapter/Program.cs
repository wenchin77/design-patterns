using System;

namespace Adapter
{
    public interface ITranslationTarget
    {
        string GetTranslation(string phrase);
    }

    class DoMeAFavorPhrases
    {
        public string Translate(string phrase)
        {
            switch (phrase)
            {
                case string x when (x.Contains("開車") || x.Contains("騎車")):
                    return "可以載我嗎？";
                case string x when (x.Contains("無聊") || x.Contains("沒事")):
                    return "陪我。";
                case string x when (x.Contains("餓") && x.Contains("晚")):
                    return "買宵夜給我吃。";
                case string x when (x.Contains("拍照") || x.Contains("好美")):
                    return "幫我拍一百張美照！";
                case string x when x.Contains("好吃"):
                    return "我想吃一口！";
                default:
                    return "(無此翻譯)";
            }
        }
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
            return _adaptee.Translate(phrase);
        }
    }

    class Program
    {
        static DoMeAFavorPhrases doMeAFavorPhrases = new DoMeAFavorPhrases();
        static ITranslationTarget targetLanguage = new PhraseAdapter(doMeAFavorPhrases);
        static void TranslateAndDisplay(string phrase)
        {
            Console.WriteLine();
            Console.WriteLine($"原始句子: {phrase}");
            Console.WriteLine($"翻譯句子: {targetLanguage.GetTranslation(phrase)}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("工具人語言翻譯機");
            TranslateAndDisplay("你要開車嗎？");
            TranslateAndDisplay("你會騎車去嗎？");
            TranslateAndDisplay("這看起來好好吃喔！");
            TranslateAndDisplay("好無聊。");
            TranslateAndDisplay("肚子餓但好晚了喔...。");
            TranslateAndDisplay("這裡好美喔！");
        }
    }
}
