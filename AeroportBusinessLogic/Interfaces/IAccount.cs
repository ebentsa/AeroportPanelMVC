using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroportBusinessLogic
{
    public interface IAccount
    {
        bool Login(LoginModel model);
        void LogOff(RegisterModel model);

        bool AddUser(RegisterModel model);
        bool CheckUser(RegisterModel model);
    }
}
