using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroportBusinessLogic.Models;

namespace AeroportBusinessLogic
{
    public interface IPassCrud
    {
        void PassAdd(Passenger passenger);
        void PassEdit(Passenger passenger);
        void PassDelete(Passenger passenger);
        Passenger PassSearch(int? id);
    }
}
