using AeroportBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using AeroportBusinessLogic.Enums;

namespace AeroportBusinessLogic.AccountMethods
{
    public class AccountManager : IAccount
    {
        public bool AddUser(RegisterModel model)
        {
            using (FlightContext db = new FlightContext())
            {
                db.Managers.Add(new Manager { Email = model.Name, Password = model.Password, Role= model.Role});
                db.SaveChanges();

                Manager user = db.Managers.FirstOrDefault(u => u.Email == model.Name);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return true;
                }
                else return false;

            }
            

        }

        public bool CheckUser(RegisterModel model)
        {
            Manager user = null;
            using (FlightContext db = new FlightContext())
            {
                user = db.Managers.FirstOrDefault(u => u.Email == model.Name);

                if (user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool Login(LoginModel model)
        {
            using (FlightContext db = new FlightContext())
            {

                Manager user = db.Managers.FirstOrDefault(u => u.Email == model.Name);

                if (user != null && (SecurePasswordHasher.Verify(model.Password, user.Password)))
                {
                    
                    return true;
                }
                else return false;

            }
        }

        public void LogOff(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
