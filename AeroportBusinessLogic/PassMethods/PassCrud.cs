using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroportBusinessLogic.Models;

namespace AeroportBusinessLogic.PassMethods
{
    public class PassCrud : IPassCrud
    {
        readonly IFlightView flightView;

        public PassCrud(IFlightView flightView)
        {
            this.flightView = flightView;
        }

        public void PassAdd(Passenger passenger)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Passengers.Add(passenger);
                db.SaveChanges();
            }
           
        }

        public void PassDelete(Passenger passenger)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Passengers.Attach(passenger);
                db.Entry(passenger).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


        public void PassEdit(Passenger passenger)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Entry(passenger).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Passenger PassSearch(int? id)
        {
            if (id != null)
            {
                using (FlightContext db = new FlightContext())
                {
                    Passenger passenger = db.Passengers.Find(id);
                    return passenger;
                }
            }
            else return null;
        }

    }
}
