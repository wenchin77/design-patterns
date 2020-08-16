using System;

namespace Bridge
{
    class DatingServiceControl
    {
        protected IDatingService _datingService;
        public DatingServiceControl(IDatingService datingService)
        {
            this._datingService = datingService;
        }
        public virtual string ToggleProfile()
        {
            if (_datingService.IsEnabled() == true)
            {
                return $"約會服務控制台 - 服務開關 -  {_datingService.DisableProfile()}";
            }
            return $"約會服務控制台 - 服務開關 -  {_datingService.EnableProfile()}";
        }
        public virtual string SetProfile(string profile)
        {
            return $"約會服務控制台 - 設定檔案 - {_datingService.SetProfile(profile)}";
        }
        public virtual string SetMatchLocation(string location)
        {
            return $"約會服務控制台 - 設定配對地點 - {_datingService.SetMatchLocation(location)} 附近方圓 10 公里";
        }
    }

    class VIPDatingServiceControl : DatingServiceControl
    {
        public VIPDatingServiceControl(IDatingService datingService) : base(datingService)
        {
        }
        public string SetAdvancedMatchLocation(string location)
        {
            if (_datingService is DatingApp)
                return $"VIP 約會服務控制台 - 設定進階配對地點 - {_datingService.SetMatchLocation(location)} 附近方圓 100 公里";
            return $"VIP 約會服務控制台 - 設定進階配對地點 - {_datingService.SetMatchLocation(location)} 附近方圓 50 公里";
        }
    }

    public interface IDatingService
    {
        bool IsEnabled();
        string EnableProfile();
        string DisableProfile();
        string SetProfile(string profile);
        string SetMatchLocation(string location);
    }

    class DatingApp : IDatingService
    {
        private bool _isEnabled;
        public bool IsEnabled() => _isEnabled;
        public string EnableProfile()
        {
            _isEnabled = true;
            return "交友軟體: 開啟";
        }
        public string DisableProfile()
        {
            _isEnabled = false;
            return "交友軟體: 關閉";
        }
        public string SetProfile(string profile)
        {
            return $"設定交友軟體檔案 ({profile})";
        }
        public string SetMatchLocation(string location) => location;
    }

    class BlindDateService : IDatingService
    {
        private bool _isEnabled;
        public bool IsEnabled() => _isEnabled;
        public string EnableProfile()
        {
            _isEnabled = true;
            return "相親服務: 開啟";
        }
        public string DisableProfile()
        {
            _isEnabled = false;
            return "相親服務: 關閉";
        }
        public string SetProfile(string profile)
        {
            return $"設定相親檔案 ({profile})";
        }
        public string SetMatchLocation(string location) => location;
    }

    class Client
    {
        public void ClientCode(DatingServiceControl control)
        {
            // Enable profile
            Console.WriteLine(control.ToggleProfile());
            var profile = "姓名: 單身狗, 年齡: 26, 性別: 男, 職業: 工程師, 配對性別: 女, 配對年齡: 18-35";
            Console.WriteLine(control.SetProfile(profile));
            if (control is VIPDatingServiceControl)
            {
                Console.WriteLine((control as VIPDatingServiceControl).SetAdvancedMatchLocation("內湖"));
            }
            else
            {
                Console.WriteLine(control.SetMatchLocation("內湖"));
            };
            // Disable profile
            Console.WriteLine(control.ToggleProfile());
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            DatingServiceControl control;
            Console.WriteLine("[ 使用交友軟體標準版 ]");
            control = new DatingServiceControl(new DatingApp());
            client.ClientCode(control);

            Console.WriteLine("[ 使用相親標準版 ]");
            control = new DatingServiceControl(new BlindDateService());
            client.ClientCode(control);

            Console.WriteLine("[ 使用交友軟體 VIP 版 ]");
            control = new VIPDatingServiceControl(new DatingApp());
            client.ClientCode(control);

            Console.WriteLine("[ 使用交友軟體 VIP 版 ]");
            control = new VIPDatingServiceControl(new BlindDateService());
            client.ClientCode(control);
        }
    }
}
