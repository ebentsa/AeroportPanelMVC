using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic.Interfaces
{
    interface IValidation
    {
        string StringValidation(string data);
        int IntConvert(string data);
    }
}
