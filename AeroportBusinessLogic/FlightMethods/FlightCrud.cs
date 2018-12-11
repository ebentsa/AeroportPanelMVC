using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.FlightMethods
{
    public class FlightCrud : IFlightCrud
    {
        public void FlightAdd(Flight flight)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Flights.Add(flight);
                db.SaveChanges();
            }
        }

        public void FlightDelete(Flight flight)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Flights.Attach(flight);
                db.Passengers.RemoveRange(flight.Passengers);
                db.Entry(flight).State = EntityState.Deleted;
                db.SaveChanges();
            }
                
        }

        public void FlightUpdate(Flight flight)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
            }
                
        }

        public List<Passenger> ShowPass(int? id)
        {
            using (FlightContext db = new FlightContext())
            {
                Flight flight = db.Flights.Find(id);
                if (flight == null)
                {
                    return null;
                }
                return flight.Passengers.ToList();
            }
        }




    }
}
