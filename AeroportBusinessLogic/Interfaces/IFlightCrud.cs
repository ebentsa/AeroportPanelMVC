using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic
{
    public interface IFlightCrud
    {
        void FlightAdd(Flight flight);
        void FlightUpdate(Flight flight);
        void FlightDelete(Flight flight);
        List<Passenger> ShowPass(int? id);
    }
}
