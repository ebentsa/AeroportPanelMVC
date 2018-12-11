using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using AeroportBusinessLogic.Enums;
using AeroportBusinessLogic.Interfaces;
using AeroportBusinessLogic.ValidationMethods;

namespace AeroportBusinessLogic
{
    public class FlightView : IFlightView
    {
        readonly IValidation validation;
        public FlightView()
        {
                this.validation = new DataValidation(); 
        }

        //Departure Flights have DepartureOrArrival - true, Arrival - false
        public List<Flight> SearchFlights(string searchData)
        {
            if (!(string.IsNullOrEmpty(searchData)))
            {
                searchData = validation.StringValidation(searchData);
                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Flights
                            where (a.FlightNum == searchData || a.FlightCity == searchData)
                            select a)
                        .ToList();
                    return SrchResult;
                }
            }

            return null;
        }
        public List<Flight> SearchDepartureFlights(string searchData)
        {
            
            if (!(string.IsNullOrEmpty(searchData)))
            {
                searchData = validation.StringValidation(searchData);

                using (FlightContext context = new FlightContext())
                {
                    var srchResult =
                        (from a in context.Flights
                            where (a.FlightNum == searchData || a.FlightCity == searchData)
                            & (a.DepartureOrArrival == true)
                            select a)
                        .ToList();
                    return srchResult;
                }
            }
            else return new List<Flight>();
        }

        public List<Flight> SearchArrivalFlights(string searchData)
        {
            if (!(string.IsNullOrEmpty(searchData)))
            {
                searchData = validation.StringValidation(searchData);

                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Flights
                            where (a.FlightNum == searchData || a.FlightCity == searchData)
                            where (a.DepartureOrArrival == false)
                            select a)
                        .ToList();
                    return SrchResult;
                }
            }
            else return new List<Flight>();
        }

        public List<Flight> SearchFlightByPrice(string lowPrice, string upPrice)
        {
            if (!(string.IsNullOrEmpty(lowPrice)&&(string.IsNullOrEmpty(upPrice))))
            {
                int.TryParse(lowPrice, out int intLowPrice);
                int.TryParse(upPrice, out int intUpPrice);

                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Flights
                            where (a.BusinessPrice >= intLowPrice && a.BusinessPrice <= intUpPrice)
                                  || (a.EconomPrice <= intUpPrice && a.EconomPrice >= intLowPrice)
                                  & (a.Flightdate > DateTime.Today.Date)
                                  & (a.DepartureOrArrival)
                            orderby a.Flightdate descending
                            select a)
                        .Take(50)
                        .ToList();
                    return SrchResult;
                }
            }
            return new List<Flight>();
        }

        public List<Flight> SearchFlightByDestination(string destination)
        {
            if (!(string.IsNullOrEmpty(destination)))
            {
                destination = validation.StringValidation(destination);

                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Flights
                            where (a.FlightCity == destination)
                                  & (a.Flightdate > DateTime.Today.Date)
                                  & (a.DepartureOrArrival)
                            orderby a.Flightdate descending
                            select a)
                        .Take(50)
                        .ToList();
                    return SrchResult;
                }
            }
            else return new List<Flight>();
        }

        public List<Flight> ViewDepartureFlights()
        {
            using (FlightContext context = new FlightContext())
            {
                var SrchResult =
                    (from a in context.Flights
                        where (a.DepartureOrArrival == true)
                        orderby a.Flightdate descending 
                     select a)
                    .Take(50)
                    .ToList();
                return SrchResult;
            }
        }
        public List<Flight> ViewArrivalFlights()
        {
            using (FlightContext context = new FlightContext())
            {
                var SrchResult =
                    (from a in context.Flights
                        where (a.DepartureOrArrival == false)
                     orderby a.Flightdate descending
                     select a).Take(50)
                    .ToList();
                return SrchResult;
            }
        }

        public List<Flight> ViewAllFlights()
        {
            using (FlightContext context = new FlightContext())
            {
                return context.Flights.ToList();
            }
        }

        public Flight SearchFlight(int? id)
        {
                using (FlightContext context = new FlightContext())
                {
                var flight = context.Flights.SingleOrDefault(a => a.FlightId == id);
                return flight;
                }
                
        }

        public List<Flight> AdminFlightsSearch(string searchData)
        {
            if (!(string.IsNullOrEmpty(searchData)))
            {
                searchData = validation.StringValidation(searchData);
                var newData = validation.IntConvert(searchData);
                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Flights
                            where (a.FlightNum == searchData || a.FlightCity == searchData || a.FlightId == newData)
                         orderby a.Flightdate descending
                         select a).
                        Take(50)
                        .ToList();
                    return SrchResult;
                }
            }
            else return new List<Flight>();
        }

        public List<Passenger> AdminPassSearch(string searchData)
        {
            if (!(string.IsNullOrEmpty(searchData)))
            {
                searchData = validation.StringValidation(searchData);
                using (FlightContext context = new FlightContext())
                {
                    var SrchResult =
                        (from a in context.Passengers
                            where (a.FirstName == searchData || a.LastName == searchData || a.Passport == searchData)
                            orderby a.FlightId descending 
                                select a)          
                        .Take(50)
                        .ToList();
                    return SrchResult;
                }
            }
            else return null;
        }
    }
}