using System;
using System.Collections.Generic;

namespace BuilderV1
{

    public interface ITripBuilder
    {
        void Reset();
        void SetDestination(string destination);
        void SetPrice();
        void SetDifficulty();
        void SetDurationHours();
        void SetMaxParticipants();
        void SetDescription();
        void SetSalesContext();
        Trip GetTrip();
    }

    public class SupTripBuilder : ITripBuilder
    {
        private Trip _trip;
        private int _price = 4000;
        private int _difficulty = 3;
        private int _durationHours = 5;
        private int _maxParticipants = 10;
        private string _description = "站著、坐著、趴著都能玩的立槳衝浪";
        private string _note = "9/1 - 9/31 SUP 行程打卡立享 9 折";
        public SupTripBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _trip = new Trip();
        }
        public void SetDestination(string destination)
        {
            _trip.AddDetail($"地點: {destination}");
        }
        public void SetPrice()
        {
            _trip.AddDetail($"每人價格: NTD {_price}");
        }
        public void SetDifficulty()
        {
            _trip.AddDetail($"困難度: {_difficulty}/5");
        }
        public void SetDurationHours()
        {
            _trip.AddDetail($"時間: {_durationHours} 小時");
        }
        public void SetMaxParticipants()
        {
            _trip.AddDetail($"每團人數限制: {_maxParticipants} 人");
        }
        public void SetDescription()
        {
            _trip.AddDetail($"SUP 活動敘述: {_description}");
        }
        public void SetSalesContext()
        {
            _trip.AddDetail($"【{_note}】");
        }
        public Trip GetTrip()
        {
            return _trip;
        }
    }

    public class KayakTripBuilder : ITripBuilder
    {
        private Trip _trip;
        private int _price = 1500;
        private int _difficulty = 2;
        private int _durationHours = 4;
        private int _maxParticipants = 20;
        private string _description = "到海上划獨木舟";
        private string _note = "使用振興券參加獨木舟行程 再折 100 元";
        public KayakTripBuilder()
        {
            Reset();
        }
        public void Reset()
        {
            _trip = new Trip();
        }
        public void SetDestination(string destination)
        {
            _trip.AddDetail($"地點: {destination}");
        }
        public void SetPrice()
        {
            _trip.AddDetail($"每人價格: NTD {_price}");
        }
        public void SetDifficulty()
        {
            _trip.AddDetail($"困難度: {_difficulty}/5");
        }
        public void SetDurationHours()
        {
            _trip.AddDetail($"時間: {_durationHours} 小時");
        }
        public void SetMaxParticipants()
        {
            _trip.AddDetail($"每團人數限制: {_maxParticipants} 人");
        }
        public void SetDescription()
        {
            _trip.AddDetail($"SUP 活動敘述: {_description}");
        }
        public void SetSalesContext()
        {
            _trip.AddDetail($"【{_note}】");
        }
        public Trip GetTrip()
        {
            return _trip;
        }
    }

    public class TripDirector
    {
        public Trip CreateTrip(ITripBuilder tripBuilder, string destination)
        {
            tripBuilder.SetSalesContext();
            tripBuilder.SetDestination(destination);
            tripBuilder.SetPrice();
            tripBuilder.SetDifficulty();
            tripBuilder.SetDurationHours();
            tripBuilder.SetMaxParticipants();
            tripBuilder.SetDescription();
            return tripBuilder.GetTrip();
        }
    }

    public class Trip
    {
        private IList<string> _tripDetail = new List<string>();
        public void AddDetail(string detail)
        {
            _tripDetail.Add(detail);
        }
        public IEnumerable<string> GetDetail()
        {
            foreach (var item in _tripDetail)
            {
                yield return item;
            }
        }
    }

    class Program
    {
        static void PrintTripDetail(IEnumerable<object> tripDetail)
        {
            foreach (var item in tripDetail)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
        }
        static void Main(string[] args)
        {
            var tripDirector = new TripDirector();
            Console.WriteLine("Trip 1. SUP 象鼻岩行程");
            var trip = tripDirector.CreateTrip(new SupTripBuilder(), "深澳象鼻岩");
            PrintTripDetail(trip.GetDetail());

            Console.WriteLine("Trip 2. SUP 龜山島行程");
            var trip1 = tripDirector.CreateTrip(new SupTripBuilder(), "龜山島牛奶湖");
            PrintTripDetail(trip1.GetDetail());

            Console.WriteLine("Trip 3. 獨木舟 東澳行程");
            var trip2 = tripDirector.CreateTrip(new SupTripBuilder(), "東澳海蝕洞");
            PrintTripDetail(trip2.GetDetail());

            Console.WriteLine("Trip 4. 獨木舟 龍洞行程");
            var trip3 = tripDirector.CreateTrip(new KayakTripBuilder(), "東北角龍洞灣");
            PrintTripDetail(trip3.GetDetail());
        }
    }
}
