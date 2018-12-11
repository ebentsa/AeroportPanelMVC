using AeroportBusinessLogic;
using AeroportBusinessLogic.FlightMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AeroportBusinessLogic.Models;
using AeroportMVCProject.Models;
using AutoMapper;


namespace AeroportWeb.Controllers
{
    public class HomeController : Controller
    {
        readonly IFlightView flightView;
        public  HomeController(IFlightView flightView)
        {
            this.flightView = flightView;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            if (name != null)
            {
                return RedirectToAction("Departure", name);
            }
            else return View("Departure");

        }


        [HttpGet]
        public ActionResult Departure()
        {
            

            return View(flightView.ViewDepartureFlights());

        }
        [HttpPost]
        public ActionResult Departure(string name)
        {
            if (name != null)
            {
                return View(flightView.SearchDepartureFlights(name));
            }
            else return View();

        }

        [HttpGet]
        public ActionResult Arrival()
        {
            return View(flightView.ViewArrivalFlights());
        }

        [HttpPost]
        public ActionResult DepartureSearch(string name)
        {
            if (name != null)
            {
                return PartialView("_CustomerFlightView", flightView.SearchDepartureFlights(name));
            }
            else return null;

        }

        [HttpPost]
        public ActionResult ArrivalSearch(string name)
        {

                return PartialView("_CustomerFlightView", flightView.SearchArrivalFlights(name));
        }

        public ActionResult Details(int id)
        {
            var flight = flightView.SearchFlight(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        [HttpGet]
        public ActionResult FlightPrices()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult FlightPricesSearch(string lowPrice, string upPrice)
        {

            return PartialView("_CustomerFlightPriceView", flightView.SearchFlightByPrice(lowPrice, upPrice));
        }

        [HttpPost]
        public ActionResult FlightDestinationSearch(string destination)
        {
            return PartialView("_CustomerFlightPriceView", flightView.SearchFlightByDestination(destination));
        }
    }
}