using System;
using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;

namespace ConsumerVehicleRegistration
{
    public class Car
    {
        public int Passengers { get; set; }
    }
}

namespace CommercialRegistration
{
    public class DeliveryTruck
    {
        public int GrossWeightClass { get; set; }
    }
}

namespace LiveryRegistration
{
    public class Taxi
    {
        public int Fares { get; set; }
    }

    public class Bus
    {
        public int Capacity { get; set; }

        public int Riders { get; set; }
    }
}


namespace NetConference2019
{
    public class Patterns
    {
        public static void Demo()
        {
            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };
            var emptyTaxi = new Taxi();
            var signleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };
            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };

            Console.WriteLine($"혼자 타고 있는 차의 톨요금은 {CalculateToll(soloDriver)}");
            Console.WriteLine($"두명이 타고 있는 차의 톨요금은 {CalculateToll(twoRideShare)}");
            Console.WriteLine($"세명이 타고 있는 차의 톨요금은 {CalculateToll(threeRideShare)}");
            Console.WriteLine($"꽉 차있는 차의 요금은 {CalculateToll(fullVan)}");
            Console.WriteLine($"빈 택시의 요금은 {CalculateToll(emptyTaxi)}");
            Console.WriteLine($"한명이 타고 있는 택시의 톨요금은 {CalculateToll(signleFare)}");
            Console.WriteLine($"둘이 타고 있는 택시의 톨요금은 {CalculateToll(doubleFare)}");
            Console.WriteLine($"꽉 차있는 택시의 톨요금은 {CalculateToll(fullVanPool)}");
            Console.WriteLine($"승객이 적은 버스의 톨요금은 {CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"승객이 적당한 버스의 톨요금은 {CalculateToll(normalBus)}");
            Console.WriteLine($"승객이 많은 버스의 톨요금은 {CalculateToll(fullBus)}");
            Console.WriteLine($"무거운 트럭의 톨요금은 {CalculateToll(heavyTruck)}");
            Console.WriteLine($"트럭의 톨요금은 {CalculateToll(truck)}");
            Console.WriteLine($"가벼운 차의 톨요금은 {CalculateToll(lightTruck)}");
        }

        public static decimal CalculateToll(object vehicle) =>
           vehicle switch
           {
               Car { Passengers: 0 } => 1000m,
               Car { Passengers: 2 } => 1500m,
               Car _ => 2000m,
               Taxi _ => 3500m,
               Bus _ => 5000m,
               DeliveryTruck _ => 10.00m,
               { } => throw new ArgumentException(message: "알려진 차 종류가 아닙니다", paramName: vehicle.GetType().Name),
               null => throw new ArgumentException(nameof(vehicle))
           };

        private static bool IsWeekDay(DateTime timeOfTall) => timeOfTall.DayOfWeek switch
        {
            DayOfWeek.Saturday => false,
            DayOfWeek.Sunday => false,
            _ => true,
        };

        private enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight,
        }

        private static TimeBand GetTimeBand(DateTime timeOfToll)
        {
            int hour = timeOfToll.Hour;
            if (hour < 6) return TimeBand.Overnight;
            else if (hour < 10) return TimeBand.MorningRush;
            else if (hour < 16) return TimeBand.Daytime;
            else if (hour < 20) return TimeBand.EveningRush;
            else return TimeBand.Overnight;
        }

        public static decimal PeakTimePremium(DateTime timeOfToll, bool inbound) =>
            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 750m,
                (true, TimeBand.Daytime, _) => 1500m,
                (true, TimeBand.MorningRush, true) => 2000m,
                (true, TimeBand.EveningRush, false) => 2000m,
                (_, _, _) => 1000m,
            };


        //public static decimal CalculateToll(object vehicle) =>
        //    vehicle switch
        //    {
        //        Car _ => 2.00m,
        //        Taxi _ => 3.50m,
        //        Bus _ => 5.00m,
        //        DeliveryTruck _ => 10.00m,
        //        { } => throw new ArgumentException(message: "알려진 차 종류가 아닙니다", paramName: vehicle.GetType().Name),
        //        null => throw new ArgumentException(nameof(vehicle))
        //    };
    }
}
