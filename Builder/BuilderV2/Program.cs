using System;
using System.Collections.Generic;

namespace BuilderV2
{
    public interface ITripBuilder
    {
        ITripBuilder SetDestination(string destination);
        ITripBuilder SetPrice(int price);
        ITripBuilder SetDifficulty(int difficulty);
        ITripBuilder SetDurationHours(int hours);
        ITripBuilder SetMaxParticipants(int maxParticipants);
        ITripBuilder SetDescription();
        ITripBuilder SetSalesContext();
        Trip Build();
    }

    public class SupTripBuilder : ITripBuilder
    {
        private Trip _trip;
        private string _description = "站著、坐著、趴著都能玩的立槳衝浪";
        private string _salesContext = "9/1 - 9/31 SUP 行程打卡立享 9 折";
        public SupTripBuilder()
        {
            _trip = new Trip();
        }
        public ITripBuilder SetDestination(string destination)
        {
            _trip.SetDestination(destination);
            return this;
        }
        public ITripBuilder SetPrice(int price)
        {
            _trip.SetPrice(price);
            return this;
        }
        public ITripBuilder SetDifficulty(int difficulty)
        {
            _trip.SetDifficulty(difficulty);
            return this;
        }
        public ITripBuilder SetDurationHours(int hours)
        {
            _trip.SetDurationHours(hours);
            return this;
        }
        public ITripBuilder SetMaxParticipants(int maxParticipants)
        {
            _trip.SetMaxParticipants(maxParticipants);
            return this;
        }
        public ITripBuilder SetDescription()
        {
            _trip.SetDescription(_description);
            return this;
        }
        public ITripBuilder SetSalesContext()
        {
            _trip.SetSalesContext(_salesContext);
            return this;
        }
        public Trip Build()
        {
            return _trip;
        }
    }

    public class Trip
    {
        private string _destination;
        private int _price;
        private int _difficulty;
        private int _hours;
        private int _maxParticipants;
        private string _description;
        private string _salesContext;
        private IList<string> _tripDetail = new List<string>();
        public IEnumerable<string> GetDetail()
        {
            foreach (var item in _tripDetail)
            {
                yield return item;
            }
        }
        // Getters to be added
        public void SetDestination(string destination)
        {
            _destination = destination;
            _tripDetail.Add($"地點: {destination}");
        }
        public void SetPrice(int price)
        {
            _price = price;
            _tripDetail.Add($"每人價格: NTD {price}");
        }
        public void SetDifficulty(int difficulty)
        {
            _difficulty = difficulty;
            _tripDetail.Add($"困難度: {difficulty}/5");
        }
        public void SetDurationHours(int hours)
        {
            _hours = hours;
            _tripDetail.Add($"時間: {hours} 小時");
        }
        public void SetMaxParticipants(int maxParticipants)
        {
            _maxParticipants = maxParticipants;
            _tripDetail.Add($"每團人數限制: {maxParticipants} 人");
        }
        public void SetDescription(string description)
        {
            _description = description;
            _tripDetail.Add($"活動敘述: {_description}");
        }
        public void SetSalesContext(string salesContext)
        {
            _salesContext = salesContext;
            _tripDetail.Add($"【{_salesContext}】");
        }
    }

    class Program
    {
        static void PrintTripDetail(Trip trip)
        {
            var tripDetail = trip.GetDetail();
            foreach (var item in tripDetail)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Trip 1. SUP 象鼻岩行程");
            Trip trip = new SupTripBuilder()
                        .SetSalesContext()
                        .SetDestination("深澳象鼻岩")
                        .SetPrice(2000)
                        .SetDifficulty(2)
                        .SetDurationHours(4)
                        .SetMaxParticipants(15)
                        .SetDescription()
                        .Build();
            PrintTripDetail(trip);

            Console.WriteLine("Trip 2. SUP 龜山島行程");
            Trip trip1 = new SupTripBuilder()
                        .SetSalesContext()
                        .SetDestination("龜山島牛奶湖")
                        .SetPrice(5000)
                        .SetDifficulty(4)
                        .SetDurationHours(6)
                        .SetMaxParticipants(10)
                        .SetDescription()
                        .Build();
            PrintTripDetail(trip1);

            Console.WriteLine("Trip 3. SUP 東澳行程");
            Trip trip2 = new SupTripBuilder()
                        .SetSalesContext()
                        .SetDestination("東澳海蝕洞")
                        .SetPrice(3500)
                        .SetDifficulty(2)
                        .Build();
            PrintTripDetail(trip2);
        }
    }
}
