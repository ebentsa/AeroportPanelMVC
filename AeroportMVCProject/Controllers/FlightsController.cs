using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AeroportBusinessLogic;
using AeroportBusinessLogic.FlightMethods;
using AeroportBusinessLogic.Models;
using AeroportBusinessLogic.PassMethods;
using AeroportMVCProject.Models;
using Autofac;
using Ninject.Activation;
using AutoMapper;

namespace AeroportWeb.Controllers
{
    [Authorize(Roles = "Manager, supervisor")]
    public class FlightsController : Controller
    {
        readonly IFlightCrud flightCrud;
        readonly IFlightView flightView;
        readonly IPassCrud passCrud;
        public FlightsController(IFlightCrud flightCrud, IFlightView flightView, IPassCrud passCrud)
        {
            this.flightCrud = flightCrud;
            this.flightView = flightView;
            this.passCrud = passCrud;
        }



        // GET: Flights
        public ActionResult Index()
        {
            return View(flightView.ViewAllFlights());
        }

        #region Flights Actions


        public ActionResult ShowPass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pass = flightCrud.ShowPass(id);
            ViewBag.Pass = id;
            if (pass == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("ShowPass",pass);
            }

        }

        public ActionResult Details(int id)
        {
            var flight = flightView.SearchFlight(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            else
            {
                

                var flight1 = Mapper.Map<Flight,FlightCreateUpdateModel>(flight);

                return View(flight1);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlightCreateUpdateModel flight)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<FlightCreateUpdateModel,Flight>());

                var flight1 = Mapper.Map<FlightCreateUpdateModel, Flight>(flight);

                flightCrud.FlightAdd(flight1);
                return RedirectToAction("Index");
            }
            return View(flight);
        }


        public ActionResult Edit(int id)
        {

            var flight = flightView.SearchFlight(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Flight, FlightCreateUpdateModel>());
                var flight1 = Mapper.Map<Flight, FlightCreateUpdateModel>(flight);

                return View(flight1);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FlightCreateUpdateModel flight)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg1 => cfg1.CreateMap<FlightCreateUpdateModel, Flight>());
                var flight1 = Mapper.Map<FlightCreateUpdateModel, Flight>(flight);

                flightCrud.FlightUpdate(flight1);
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        public ActionResult Delete(int id)
        {
            var flight = flightView.SearchFlight(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            else
            {
                

                var flight1 = Mapper.Map<Flight, FlightCreateUpdateModel>(flight);

                return View(flight1);
            }

            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {


            var flight = flightView.SearchFlight(id);
            flightCrud.FlightDelete(flight);

            
            return RedirectToAction("Index");
        }
        #endregion
        #region Passanger Actions
        public ActionResult CreatePass(int? id)
        {
            //proverka
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.FlightId = id;
            var flight = flightView.SearchFlight(id);
            ViewBag.FlightNum = flight.FlightNum;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePass(Passenger passenger)
        {
            if (ModelState.IsValid)
            {   
                passCrud.PassAdd(passenger);
                //int flightId = (int)passenger.FlightId;
                return RedirectToAction("Index");
            }
            //ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightNum", passenger.FlightId);
            return View(passenger);
        }

        public ActionResult DetailsPass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = passCrud.PassSearch(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }


        public ActionResult EditPass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = passCrud.PassSearch(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass( Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                passCrud.PassEdit(passenger);
                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        
        public ActionResult DeletePass(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = passCrud.PassSearch(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }


        [HttpPost, ActionName("DeletePass")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePassConfirmed(int? id)
        {
            var pass = passCrud.PassSearch(id);
            passCrud.PassDelete(pass);

            return RedirectToAction("Index");
        }
        #endregion

        #region AdminSearch Actions
        [HttpPost]
        public ActionResult AdminFlightSearch(string flightData)
        {
            if (flightData != null)
            {
                return PartialView("_AdminFlightView", flightView.AdminFlightsSearch(flightData));
            }
            else return View( "Index", new List<Flight>());

        }

        [HttpPost]
        public ActionResult AdminPassSearch(string passData)
        {

            return PartialView("_AdminPassView", flightView.AdminPassSearch(passData));
        }
#endregion
    }
}
