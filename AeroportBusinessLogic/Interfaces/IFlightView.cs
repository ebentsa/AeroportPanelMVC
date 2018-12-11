using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic
{
    public interface IFlightView
    {
        List<Flight> SearchFlights(string searchData);
        List<Flight> SearchDepartureFlights(string searchData);
        List<Flight> SearchArrivalFlights(string searchData);
        List<Flight> ViewDepartureFlights();
        List<Flight> ViewArrivalFlights();
        List<Flight> ViewAllFlights();
        Flight SearchFlight(int? id);
        List<Flight> SearchFlightByPrice(string lowPrice, string upPrice);
        List<Flight> SearchFlightByDestination(string destination);

        List<Flight> AdminFlightsSearch(string searchData);
        List<Passenger> AdminPassSearch(string searchData);
    }
}
