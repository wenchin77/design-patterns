using System;
using System.Collections.Generic;

namespace Composite
{
    abstract class Component
    {
        public string Title;
        public Component() { }
        public abstract string Display();
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    class Leaf : Component
    {
        public Leaf(string title)
        {
            this.Title = title;
        }
        public override string Display()
        {
            return this.Title;
        }
        public override bool IsComposite()
        {
            return false;
        }
    }

    class Composite : Component
    {
        public Composite(string title)
        {
            this.Title = title;
        }
        protected List<Component> _children = new List<Component>();
        public override void Add(Component component)
        {
            this._children.Add(component);
        }
        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }
        // 用遞迴的方式印出整個 composite 內容
        public override string Display()
        {
            int i = 0;
            string result = $"\n(Branch {this.Title})\n";
            foreach (Component component in this._children)
            {
                result += component.Display();
                if (i != this._children.Count)
                {
                    result += "\n";
                }
                i++;
            }
            return result + "(end branch or node)\n";
        }
    }

    class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine($"RESULT:{component.Display()}");
        }
        public void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }
            Console.WriteLine($"RESULT:{component1.Display()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Client: 把諸多派對元素組合成成一棵樹\n");
            Composite tree = new Composite("生日趴活動");
            Composite branch1 = new Composite("活動進行組");
            branch1.Add(new Leaf("DJ 放歌"));
            branch1.Add(new Leaf("調酒師調酒"));
            Composite branch2 = new Composite("活動紀錄組");
            branch2.Add(new Leaf("攝影師拍活動照片"));
            tree.Add(branch1);
            tree.Add(branch2);
            client.ClientCode(tree);

            Console.WriteLine("Client: 添加元素調整樹 (不需要確認原先元素的類別)\n");
            client.ClientCode2(tree, new Leaf("趴踢工作人員資料紀錄"));
        }
    }
}
