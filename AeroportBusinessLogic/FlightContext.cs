using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AeroportBusinessLogic.AccountMethods;
using AeroportBusinessLogic.Enums;

namespace AeroportBusinessLogic
{
    public class FlightContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }

    public class FlightDbInitializer : DropCreateDatabaseAlways<FlightContext>
    {
        public FlightDbInitializer()
        {
            
        }
        protected override void Seed(FlightContext context)
        {
            Passenger ps1 = new Passenger
            {
                PassengerId = 0,
                PassFlNumber = "N432",
                FirstName = "IVAN",
                LastName = "IVANOV",
                Nationality = "UKRAINE",
                Passport = "TR435261",
                Birthday = DateTime.Parse("01/02/2018"),
                Sex = PassSex.Woman,
                FlClass = FlightClass.Business,
            };
            Passenger ps2 = new Passenger
            {
                PassengerId = 1,
                PassFlNumber = "N432",
                FirstName = "PETRO",
                LastName = "IVANOV",
                Nationality = "UKRAINE",
                Passport = "TR435261",
                Birthday = DateTime.Parse("01/02/2014"),
                Sex = PassSex.Man,
                FlClass = FlightClass.Econom,
            };
            Passenger ps3 = new Passenger
            {
                PassengerId = 2,
                PassFlNumber = "N432",
                FirstName = "PETRO",
                LastName = "PETROV",
                Nationality = "BELARUS",
                Passport = "TR435261",
                Birthday = DateTime.Parse("01/02/2014"),
                Sex = PassSex.Woman,
                FlClass = FlightClass.Business,
            };

            context.Passengers.Add(ps1);
            context.Passengers.Add(ps2);
            context.Passengers.Add(ps3);

            Flight fl1 = new Flight
            {
                FlightId = 1,
                DepartureOrArrival = true,
                FlightNum = "N435",
                Flightdate = DateTime.Parse("12/07/2018 13:03:13"),
                FlightCity = "KIEV",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.CheckIn,
                FlightGate = "B",
                BusinessPrice = 199,
                EconomPrice = 30,
                Passengers = new List<Passenger>() { ps1, ps2 }
            };
            Flight fl2 = new Flight
            {
                FlightId = 2,
                DepartureOrArrival = true,
                FlightNum = "N435",
                Flightdate = DateTime.Parse("12/12/2018 14:03:13"),
                FlightCity = "DNEPR",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.Canceled,
                FlightGate = "B",
                BusinessPrice = 199,
                EconomPrice = 10,
                Passengers = new List<Passenger>() { ps1 }
            };
            Flight fl3 = new Flight()
            {
                FlightId = 3,
                DepartureOrArrival = false,
                FlightNum = "N435",
                Flightdate = DateTime.Parse("01/03/2019 14:03:13"),
                FlightCity = "KIEV",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.Arrived,
                FlightGate = "B",
                BusinessPrice = 199,
                EconomPrice = 10,
                Passengers = new List<Passenger>() { }
            };

            Flight fl4 = new Flight
            {
                FlightId = 4,
                DepartureOrArrival = true,
                FlightNum = "N432",
                Flightdate = DateTime.Parse("12/27/2018 14:03:13"),
                FlightCity = "MADRID",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.InFlight,
                FlightGate = "B",
                BusinessPrice = 199,
                EconomPrice = 10,
                Passengers = new List<Passenger>() { ps1, ps2 }
            };
            Flight fl5 = new Flight
            {
                FlightId = 5,
                DepartureOrArrival = true,
                FlightNum = "N432",
                Flightdate = DateTime.Parse("12/15/2018 15:03:13"),
                FlightCity = "DNEPR",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.CheckIn,
                FlightGate = "B",
                BusinessPrice = 199,
                EconomPrice = 10,
                Passengers = new List<Passenger>() { ps1 }
            };
            Flight fl6 = new Flight()
            {
                FlightId = 6,
                DepartureOrArrival = true,
                FlightNum = "N437",
                Flightdate = DateTime.Parse("12/15/2018 12:03:13"),
                FlightCity = "KIEV",
                FlightAirline = "MAU",
                FlightTerminal = "D",
                FlightStat = FlightStatusEnum.CheckIn,
                FlightGate = "B",
                BusinessPrice = 75,
                EconomPrice = 10,
                Passengers = new List<Passenger>() { }
            };

            context.Flights.Add(fl1);
            context.Flights.Add(fl3);
            context.Flights.Add(fl2);
            context.Flights.Add(fl4);
            context.Flights.Add(fl5);
            context.Flights.Add(fl6);


            context.Managers.Add(new Manager()
            {
                Id = 0,
                Email = "manager@gmail.com",
                Password = SecurePasswordHasher.Hash("1234"),
                Role = RoleEnum.Manager

            });
            context.Managers.Add(new Manager()
            {
                Id = 1,
                Email = "supervisor@gmail.com",
                Password = SecurePasswordHasher.Hash("2345"),
                Role = RoleEnum.Supervisor

            });

            context.SaveChanges();
        }
    }

}